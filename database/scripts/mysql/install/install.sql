SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `metrotama` DEFAULT CHARACTER SET utf8 COLLATE utf8_bin ;
USE `metrotama` ;

-- -----------------------------------------------------
-- Table `metrotama`.`User`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `metrotama`.`User` (
  `UserId` INT NOT NULL ,
  `UserName` VARCHAR(250) NOT NULL ,
  `NickName` VARCHAR(250) NOT NULL ,
  `PetPoints` INT NOT NULL DEFAULT 100 ,
  PRIMARY KEY (`UserId`) ,
  UNIQUE INDEX `userName_UNIQUE` (`UserName` ASC) ,
  UNIQUE INDEX `NickName_UNIQUE` (`NickName` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `metrotama`.`Stage`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `metrotama`.`Stage` (
  `StageId` INT NOT NULL ,
  `StageName` VARCHAR(45) NOT NULL ,
  `AgeFrom` INT NOT NULL ,
  `AgeTo` INT NOT NULL ,
  `HealthInterval` INT NOT NULL ,
  `HealthCoeff` INT NOT NULL ,
  `HungerInterval` INT NOT NULL ,
  `HungerCoeff` INT NOT NULL ,
  `HygeneInterval` INT NOT NULL ,
  `HygeneCoeff` INT NOT NULL ,
  `DisciplineInterval` INT NOT NULL ,
  `DisciplineCoeff` INT NOT NULL ,
  `MoodInterval` INT NOT NULL ,
  `MoodCoeff` INT NOT NULL ,
  `EnergyInterval` INT NOT NULL ,
  `EnergyCoeff` INT NOT NULL ,
  PRIMARY KEY (`StageId`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `metrotama`.`GameObject`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `metrotama`.`GameObject` (
  `GameObjectId` INT NOT NULL ,
  `ObjectName` VARCHAR(200) NOT NULL ,
  `Description` VARCHAR(250) NOT NULL DEFAULT 'No Description' ,
  `HealthEffect` INT NOT NULL DEFAULT 0 ,
  `HungerEffect` INT NOT NULL DEFAULT 0 ,
  `HygeneEffect` INT NOT NULL DEFAULT 0 ,
  `DisciplineEffect` INT NOT NULL DEFAULT 0 ,
  `MoodEffect` INT NOT NULL DEFAULT 0 ,
  `EnergyEffect` INT NOT NULL DEFAULT 0 ,
  `Price` INT NOT NULL DEFAULT 0 ,
  PRIMARY KEY (`GameObjectId`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `metrotama`.`Pet`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `metrotama`.`Pet` (
  `PetId` INT NOT NULL ,
  `UserId` INT NOT NULL ,
  `StageId` INT NOT NULL ,
  `FavoriteObjectId` INT NULL ,
  `DislikeObjectId` INT NULL ,
  `Name` VARCHAR(250) NOT NULL ,
  `Health` INT NOT NULL DEFAULT 100 ,
  `Hygene` INT NOT NULL DEFAULT 100 ,
  `Hunger` INT NOT NULL DEFAULT 100 ,
  `Energy` INT NOT NULL DEFAULT 100 ,
  `Discipline` INT NOT NULL DEFAULT 0 ,
  `Mood` INT NOT NULL DEFAULT 100 ,
  `Gender` INT NOT NULL ,
  `Age` INT NOT NULL DEFAULT 0 ,
  `LastUpdated` DATETIME NOT NULL ,
  PRIMARY KEY (`PetId`) ,
  INDEX `UserPet_idx` (`UserId` ASC) ,
  INDEX `StagePet_idx` (`StageId` ASC) ,
  INDEX `DislikeObjectPet_idx` (`DislikeObjectId` ASC) ,
  INDEX `FavoriteObjectPet_idx` (`FavoriteObjectId` ASC) ,
  CONSTRAINT `UserPet`
    FOREIGN KEY (`UserId` )
    REFERENCES `metrotama`.`User` (`UserId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `StagePet`
    FOREIGN KEY (`StageId` )
    REFERENCES `metrotama`.`Stage` (`StageId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `DislikeObjectPet`
    FOREIGN KEY (`DislikeObjectId` )
    REFERENCES `metrotama`.`GameObject` (`GameObjectId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FavoriteObjectPet`
    FOREIGN KEY (`FavoriteObjectId` )
    REFERENCES `metrotama`.`GameObject` (`GameObjectId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `metrotama`.`GraveYard`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `metrotama`.`GraveYard` (
  `GraveYardId` INT NOT NULL ,
  `PetId` INT NOT NULL ,
  `TimeDied` DATETIME NOT NULL ,
  `LastThought` VARCHAR(250) NOT NULL DEFAULT 'Nothing' ,
  PRIMARY KEY (`GraveYardId`) ,
  UNIQUE INDEX `PetId_UNIQUE` (`PetId` ASC) ,
  CONSTRAINT `GraveYardPet`
    FOREIGN KEY (`PetId` )
    REFERENCES `metrotama`.`Pet` (`PetId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `metrotama`.`SayText`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `metrotama`.`SayText` (
  `SayTextId` INT NOT NULL ,
  `Parametter` INT NOT NULL ,
  `From` INT NOT NULL DEFAULT 0 ,
  `To` INT NOT NULL DEFAULT 0 ,
  `Text` VARCHAR(250) NOT NULL DEFAULT 'Nothing' ,
  PRIMARY KEY (`SayTextId`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `metrotama`.`Highscore`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `metrotama`.`Highscore` (
  `HighscoreId` INT NOT NULL ,
  `UserId` INT NOT NULL ,
  `GameObjectId` INT NOT NULL ,
  `Score` INT NOT NULL DEFAULT 0 ,
  PRIMARY KEY (`HighscoreId`) ,
  INDEX `HighscoreUser_idx` (`UserId` ASC) ,
  INDEX `HighscoreObject_idx` (`GameObjectId` ASC) ,
  CONSTRAINT `HighscoreUser`
    FOREIGN KEY (`UserId` )
    REFERENCES `metrotama`.`User` (`UserId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `HighscoreObject`
    FOREIGN KEY (`GameObjectId` )
    REFERENCES `metrotama`.`GameObject` (`GameObjectId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `metrotama`.`Achievement`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `metrotama`.`Achievement` (
  `AchievementId` INT NOT NULL ,
  `Title` VARCHAR(200) NOT NULL ,
  `Description` VARCHAR(250) NOT NULL ,
  `Highscore` INT NOT NULL DEFAULT 0 ,
  `AwardPoints` INT NOT NULL DEFAULT 0 ,
  `Category` INT NOT NULL ,
  PRIMARY KEY (`AchievementId`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `metrotama`.`AchievementUser`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `metrotama`.`AchievementUser` (
  `AchievementId` INT NOT NULL ,
  `UserId` INT NOT NULL ,
  PRIMARY KEY (`AchievementId`, `UserId`) ,
  INDEX `AchievementUserUser_idx` (`UserId` ASC) ,
  INDEX `AchievementUserAchievement_idx` (`AchievementId` ASC) ,
  CONSTRAINT `AchievementUserUser`
    FOREIGN KEY (`UserId` )
    REFERENCES `metrotama`.`User` (`UserId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `AchievementUserAchievement`
    FOREIGN KEY (`AchievementId` )
    REFERENCES `metrotama`.`Achievement` (`AchievementId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `metrotama` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
