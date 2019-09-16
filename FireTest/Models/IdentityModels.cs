using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;


namespace FireTest.Models
{
    //Role administrator moderator teacher user guest 
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
        public string OLDID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public string Avatar { get; set; }
        public int Course { get; set; }
        public int Year { get; set; }

        public double Rating { get; set; }
        public int AnswersCount { get; set; }
        public int CorrectAnswersCount { get; set; }
        public bool Busy { get; set; }
        public DateTime LastActivity { get; set; }
        public bool Sex { get; set; }
        public string Region { get; set; }
        public bool Master { get; set; }

        public long? FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public long? BattleId { get; set; }
        public virtual Battle Battle { get; set; }
        public virtual ICollection<TestByTeacher> TestsByTeacher { get; set; }
        public virtual ICollection<TestByDiscipline> TestsByDiscipline { get; set; }
        public virtual ICollection<TestByLevel> TestsByLevel { get; set; }
        public virtual ICollection<TestByBattle> TestsByBattle { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
        public virtual ICollection<LevelStatistic> LevelStatistics { get; set; }
        public virtual ICollection<DisciplineStatistic> DisciplineStatistics { get; set; }
        public virtual ICollection<BattleStatistic> BattleStatistics { get; set; }

        public User()
        {
            BattleStatistics = new List<BattleStatistic>();
            DisciplineStatistics = new List<DisciplineStatistic>();
            LevelStatistics = new List<LevelStatistic>();
            TestsByTeacher = new List<TestByTeacher>();
            TestsByDiscipline = new List<TestByDiscipline>();
            TestsByLevel = new List<TestByLevel>();
            Disciplines = new List<Discipline>();
            TestsByBattle = new List<TestByBattle>();
        }
    }
    public class Faculty
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Bachelor { get; set; }
        public int Master { get; set; }

        public virtual ICollection<Level> Levels { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public Faculty()
        {
            Levels = new List<Level>();
            Questions = new List<Question>();
            Users = new List<User>();
        }
    } //Факультет
    public class Level
    {
        public long Id { get; set; }
        public int Course { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public long FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
    public class LevelScore
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public long? LevelId { get; set; }
        public virtual Level Level { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
    public class Discipline
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int OLDID { get; set; }

        public long? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<DisciplineStatistic> Statistics { get; set; }
        public Discipline()
        {
            Statistics = new List<DisciplineStatistic>();
            Issues = new List<Issue>();
            Users = new List<User>();
            Questions = new List<Question>();
        }
    }//Предмет
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Discipline> Disciplines { get; set; }
        public Department()
        {
            Disciplines = new List<Discipline>();
        }
    } //Кафедра
    public class Question //Вопрос
    {
        public long Id { get; set; }
        public int OLDId { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int AnswerType { get; set; } //1-один; 2-много; 3-очередность; 4-соответствие
        public int CountAll { get; set; }
        public int CountCorrect { get; set; }
        public bool InLevel { get; set; }
        public int Course { get; set; }

        public long? TagId { get; set; }
        public virtual Tag Tag { get; set; }
        public long? DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual ICollection<TeacherTest> TeacherTests { get; set; }
        public virtual ICollection<TestByLevel> TestsByLevel { get; set; }
        public virtual ICollection<TestByDiscipline> TestByDisciplines { get; set; }
        public virtual ICollection<Faculty> Facultys { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Battle> Battles { get; set; }
        public Question()
        {
            Facultys = new List<Faculty>();
            TestByDisciplines = new List<TestByDiscipline>();
            TestsByLevel = new List<TestByLevel>();
            TeacherTests = new List<TeacherTest>();
            Answers = new List<Answer>();
            Battles = new List<Battle>();
        }
    }
    public class Tag
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public Tag()
        {
            Questions = new List<Question>();
        }
    }
    public class EducationalMaterial
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long? TagId { get; set; }
        public virtual Tag Tag { get; set; }
        public long? QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
    public class Answer
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool Correct { get; set; }
        //Если один или более правильных, то у них тру
        //Если ответ на последовательность, то в очередности как сохранены и все тру
        //Если на соответствие, то все тру и опять же как сохранены 1 и 4 2 и 3 и т.д.
        public long QuestionId { get; set; }
        public virtual Question Question { get; set; }
    } //Ответ
    public class MessageOfTheDay //для учителей и админов
    {
        public long Id { get; set; }
        public string Message { get; set; }
    }
    public class Issue
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public long? DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }
        public long QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string TeacherId { get; set; }
        public virtual User Teacher { get; set; }
    }
    public class TeacherTest //Тестирования обычные и итоговые
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public bool Final { get; set; } //Это для финального тестирования по уровню подготовки
        public int Course { get; set; } //Это для финального тестирования по уровню подготовки
        public long? FacultyId { get; set; } //Это для финального тестирования по уровню подготовки
        public virtual Faculty Faculty { get; set; } //Это для финального тестирования по уровню подготовки

        public int Eval5 { get; set; }
        public int Eval4 { get; set; }
        public int Eval3 { get; set; }

        public string TeacherId { get; set; }
        public virtual User Teacher { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TeacherExamSchedule> ExamsSchedule { get; set; }
        public TeacherTest()
        {
            Questions = new List<Question>();
            ExamsSchedule = new List<TeacherExamSchedule>();
        }
    }
    public class TeacherExamSchedule //Планирование тестирования
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public int TimeForExam { get; set; }
        public string Classroom { get; set; }
        public string Annotations { get; set; }

        public long TeacherTestId { get; set; }
        public virtual TeacherTest TeacherTest { get; set; }
        public virtual ICollection<TestByTeacher> TestsByTeacher { get; set; }
        public virtual ICollection<User> Users { get; set; } //Добавляем пользователя когда его допустили
        public TeacherExamSchedule()
        {
            Users = new List<User>();
            TestsByTeacher = new List<TestByTeacher>();
        }
    }
    public class TestByTeacher //То что юзер начал тестироваться и оценка, если 0 то не закончил и если время конца равно началу. 
    {
        public long Id { get; set; }
        public DateTime StartExam { get; set; }
        public DateTime EndExam { get; set; }
        public int Score { get; set; }

        public long? TeacherExamScheduleId { get; set; }
        public virtual TeacherExamSchedule TeacherExamSchedule { get; set; }
        public virtual ICollection<AnswerByUser> AnswersByUser { get; set; }
        public TestByTeacher()
        {
            AnswersByUser = new List<AnswerByUser>();
        }
    }
    public class TestByLevel //закончилоась когда время конца не равно и не меньше времени старта
    {
        public long Id { get; set; }
        public int Course { get; set; }

        public DateTime StartTest { get; set; }
        public DateTime EndTest { get; set; }
        public bool End { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<AnswerByUser> AnswersByUser { get; set; }
        public TestByLevel()
        {
            AnswersByUser = new List<AnswerByUser>();
            Questions = new List<Question>();
        }
    } //Селфиквалификация
    public class TestByDiscipline //закончилоась когда время конца не равно и не меньше времени старта
    {
        public long Id { get; set; }

        public DateTime StartTest { get; set; }
        public DateTime EndTest { get; set; }
        public bool End { get; set; }
        public int Course { get; set; }

        public long DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<AnswerByUser> AnswersByUser { get; set; }
        public TestByDiscipline()
        {
            Questions = new List<Question>();
            AnswersByUser = new List<AnswerByUser>();
        }
    } // СелфиПредмет
    public class TestByBattle
    {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
        public long BattleId { get; set; }
        public virtual Battle Battle { get; set; }
        public virtual ICollection<AnswerByUser> AnswersByUser { get; set; }
        public TestByBattle()
        {
            AnswersByUser = new List<AnswerByUser>();
        }
    }
    public class Battle //закончилоась когда время конца не равно и не меньше времени старта
    {
        public long Id { get; set; }
        public int Course { get; set; }
        public DateTime InviteTime { get; set; }
        public string WinnerId { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Battle()
        {
            Questions = new List<Question>();
            Users = new List<User>();
        }
    } // СелфиПредмет
    public class AnswerByUser
    {
        public long Id { get; set; }
        public bool Correct { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
        public long? TestByTeacherId { get; set; }
        public virtual TestByTeacher TestByTeacher { get; set; }
        public long? TestByDisciplineId { get; set; }
        public virtual TestByDiscipline TestByDiscipline { get; set; }
        public long? TestByLevelId { get; set; }
        public virtual TestByLevel TestByLevel { get; set; }
        public long QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public long? BattleId { get; set; }
        public virtual Battle Battle { get; set; }
    }
    public class LevelStatistic
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int Course { get; set; }
        public int Count { get; set; }
        public int CountQuestions { get; set; }
        public int CountCorrectAnswers { get; set; }

        public string Group { get; set; }
        public long FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
    public class DisciplineStatistic
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int Course { get; set; }//потом сохранять и курс вопросов предмета
        public int Count { get; set; }
        public int CountQuestions { get; set; }
        public int CountCorrectAnswers { get; set; }

        public string Group { get; set; }
        public long FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public long DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }
        public string UserId { get; set; }
        public virtual User Users { get; set; }
    }
    public class BattleStatistic
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int Course { get; set; }
        public int Count { get; set; }
        public int WinCount { get; set; }
        public int CountQuestions { get; set; }
        public int CountCorrectAnswers { get; set; }
        public string Group { get; set; }
        public long FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public string UserId { get; set; }
        public virtual User Users { get; set; }
    }
    public class DBContext : IdentityDbContext<User>
    {
        public DBContext()
            : base("Connection", throwIfV1Schema: false)
        {
        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Faculty> Facultys { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TeacherTest> TeacherTests { get; set; }
        public DbSet<TeacherExamSchedule> TeacherExamsSchedule { get; set; }
        public DbSet<TestByTeacher> TestsByTeacher { get; set; }
        public DbSet<TestByBattle> TestsByBattle { get; set; }
        public DbSet<TestByLevel> TestsByLevel { get; set; }
        public DbSet<TestByDiscipline> TestsByDiscipline { get; set; }
        public DbSet<AnswerByUser> AnswersByUser { get; set; }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<MessageOfTheDay> MessageOfTheDays { get; set; }

        public DbSet<Battle> Battles { get; set; }
        public DbSet<LevelScore> LevelsScore { get; set; }
        public DbSet<LevelStatistic> LevelStatistics { get; set; }
        public DbSet<DisciplineStatistic> DisciplineStatistics { get; set; }
        public DbSet<BattleStatistic> BattleStatistics { get; set; }
        public DbSet<EducationalMaterial> EducationalMaterials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UsersRole");
            modelBuilder.Entity<User>().ToTable("Users", "dbo");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("_UsersClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("_UsersLogin");
            modelBuilder.Entity<User>().Ignore(x => x.PhoneNumber);
            modelBuilder.Entity<User>().Ignore(x => x.PhoneNumberConfirmed);
            modelBuilder.Entity<User>().Ignore(x => x.TwoFactorEnabled);
        }
        public static DBContext Create()
        {
            return new DBContext();
        }
    }
}