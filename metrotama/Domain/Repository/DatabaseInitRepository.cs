using metrotama.Domain.Enumerator;
using metrotama.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace metrotama.Domain.Repository
{
    class DatabaseInitRepository
    {
        private static UserRepository UserRepo = new UserRepository();
        public void InitializeTables()
        {
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                db.CreateTable<User>();
                db.CreateTable<Pet>();
                db.CreateTable<PetStage>();
                db.CreateTable<SayText>();
                db.CreateTable<Highscore>();
                db.CreateTable<GraveYard>();
                db.CreateTable<GameObject>();
                db.CreateTable<Achievement>();
                db.CreateTable<AchievementUser>();
            }
        }

        public void InitializeData()
        {
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                //Clear tables (for DEV purpoises only!)
                //TODO: later remove
                db.DeleteAll<User>();
                db.DeleteAll<Pet>();
                db.DeleteAll<PetStage>();
                db.DeleteAll<GameObject>();
                //User
                InserUser(db);
                //Pet
                InserPet(db);
                //Pet stages
                InsertPetStages(db);
                //Game objects
                InsertFood(db);
                InserActivities(db);
            }
        }

        private void InserActivities(SQLiteConnection db)
        {
            db.Insert(new GameObject()
            {
                GameObjectId = (int)GameObjectEnum.BALL,
                ObjectName = "Ball",
                Description = "Play a simple ball game",
                HealthEffect = 0,
                HungerEffect = -5,
                HygeneEffect = -5,
                DisciplineEffect = 0,
                MoodEffect = 8,
                EnergyEffect = -10,
                Price = 0
            });
            db.Insert(new GameObject()
            {
                GameObjectId = (int)GameObjectEnum.BOOK,
                ObjectName = "Book",
                Description = "Read a book",
                HealthEffect = 0,
                HungerEffect = -5,
                HygeneEffect = 0,
                DisciplineEffect = 5,
                MoodEffect = 5,
                EnergyEffect = -8,
                Price = 0
            });
        }

        private static void InsertFood(SQLiteConnection db)
        {
            db.Insert(new GameObject()
            {
                GameObjectId = (int)GameObjectEnum.APPLE,
                ObjectName = "Apple",
                Description = "Healthy apple",
                HealthEffect = 5,
                HungerEffect = 5,
                HygeneEffect = 0,
                DisciplineEffect = 0,
                MoodEffect = 5,
                EnergyEffect = 3,
                Price = 2
            });
            db.Insert(new GameObject()
            {
                GameObjectId = (int)GameObjectEnum.BURGER,
                ObjectName = "Burger",
                Description = "Lotsofcaloriesburger, with cheese and stuff!",
                HealthEffect = -2,
                HungerEffect = 10,
                HygeneEffect = -2,
                DisciplineEffect = 0,
                MoodEffect = 5,
                EnergyEffect = 6,
                Price = 4
            });
            db.Insert(new GameObject()
            {
                GameObjectId = (int)GameObjectEnum.WATTER,
                ObjectName = "Watter",
                Description = "A refreshing glass of watter",
                HealthEffect = 1,
                HungerEffect = 2,
                HygeneEffect = 0,
                DisciplineEffect = 0,
                MoodEffect = 3,
                EnergyEffect = 5,
                Price = 1
            });
        }

        private static void InsertPetStages(SQLiteConnection db)
        {
            db.Insert(new PetStage()
            {
                PetStageId = (int)PetStageEnum.EGG,
                AgeFrom = 0,
                AgeTo = 1,
                HealthInterval = 0,
                HealthCoeff = 0,
                HungerInterval = 0,
                HungerCoeff = 0,
                HygeneInterval = 0,
                HygeneCoeff = 0,
                DisciplineInterval = 0,
                DisciplineCoeff = 0,
                MoodInterval = 0,
                MoodCoeff = 0,
                EnergyInterval = 0,
                EnergyCoeff = 0
            });

            db.Insert(new PetStage()
            {
                PetStageId = (int)PetStageEnum.BABY,
                AgeFrom = 1,
                AgeTo = 6,
                HealthInterval = 30,
                HealthCoeff = 1,
                HungerInterval = 10,
                HungerCoeff = 2,
                HygeneInterval = 10,
                HygeneCoeff = 3,
                DisciplineInterval = 0,
                DisciplineCoeff = 0,
                MoodInterval = 10,
                MoodCoeff = 2,
                EnergyInterval = 10,
                EnergyCoeff = 3
            });
            db.Insert(new PetStage()
            {
                PetStageId = (int)PetStageEnum.CHILD,
                AgeFrom = 6,
                AgeTo = 11,
                HealthInterval = 10,
                HealthCoeff = 3,
                HungerInterval = 15,
                HungerCoeff = 2,
                HygeneInterval = 10,
                HygeneCoeff = 3,
                DisciplineInterval = 10,
                DisciplineCoeff = 4,
                MoodInterval = 10,
                MoodCoeff = 4,
                EnergyInterval = 20,
                EnergyCoeff = 3
            });
            db.Insert(new PetStage()
            {
                PetStageId = (int)PetStageEnum.TEEN,
                AgeFrom = 11,
                AgeTo = 21,
                HealthInterval = 10,
                HealthCoeff = 4,
                HungerInterval = 10,
                HungerCoeff = 3,
                HygeneInterval = 30,
                HygeneCoeff = 3,
                DisciplineInterval = 30,
                DisciplineCoeff = 3,
                MoodInterval = 30,
                MoodCoeff = 3,
                EnergyInterval = 30,
                EnergyCoeff = 2
            });
            db.Insert(new PetStage()
            {
                PetStageId = (int)PetStageEnum.ADULT,
                AgeFrom = 21,
                AgeTo = 50,
                HealthInterval = 30,
                HealthCoeff = 4,
                HungerInterval = 30,
                HungerCoeff = 4,
                HygeneInterval = 40,
                HygeneCoeff = 2,
                DisciplineInterval = 40,
                DisciplineCoeff = 1,
                MoodInterval = 40,
                MoodCoeff = 3,
                EnergyInterval = 30,
                EnergyCoeff = 3
            });
            db.Insert(new PetStage()
            {
                PetStageId = (int)PetStageEnum.SENIOR,
                AgeFrom = 50,
                AgeTo = 999,
                HealthInterval = 10,
                HealthCoeff = 2,
                HungerInterval = 30,
                HungerCoeff = 2,
                HygeneInterval = 10,
                HygeneCoeff = 3,
                DisciplineInterval = 60,
                DisciplineCoeff = 2,
                MoodInterval = 60,
                MoodCoeff = 3,
                EnergyInterval = 10,
                EnergyCoeff = 3
            });
        }

        private static void InserPet(SQLiteConnection db)
        {
            db.Insert(new Pet()
            {
                UserId = UserRepo.GetUserByName(App.CurrentUserName).UserId,
                PetStageId = (int)PetStageEnum.EGG,
                FavoriteGameObjectId = (int)GameObjectEnum.APPLE,
                DislikeGameObjectId = (int)GameObjectEnum.BURGER,
                Name = string.Empty,
                Health = 100,
                Hygene = 100,
                Hunger = 100,
                Energy = 100,
                Discipline = 0,
                Mood = 100,
                Gender = (int)GenderEnum.MALE,
                Age = 0,
                LastUpdated = DateTime.Now
            });
        }

        private static void InserUser(SQLiteConnection db)
        {
            db.Insert(new User()
            {
                UserName = App.CurrentUserName,
                NickName = String.Empty,
                PetPoints = 100
            });
        }
    }
}
