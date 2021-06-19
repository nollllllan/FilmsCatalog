using System;
using FilmsCatalog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace FilmsCatalog.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasOne(x => x.User);

            base.OnModelCreating(modelBuilder);
            SeedUsers(modelBuilder);
            SeedFilms(modelBuilder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            var user = new User
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@gmail.com",
                FirstName = "Тест",
                LastName = "Тестов",
                MiddleName = "Тестович",
            };

            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, "Admin*123");

            var user2 = new User
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e6",
                Email = "admin2@gmail.com",
                UserName = "admin2@gmail.com",
                FirstName = "Тест2",
                LastName = "Тестов2",
                MiddleName = "Тестович",
            };

            user2.PasswordHash = new PasswordHasher<User>().HashPassword(user2, "Admin*1234");

            builder.Entity<User>().HasData(user, user2);
        }

        private void SeedFilms(ModelBuilder builder)
        {
            const string userId = "b74ddd14-6340-4840-95c2-db12554843e5";
            const string user2Id = "b74ddd14-6340-4840-95c2-db12554843e6";

            builder.Entity<Film>().HasData(new Film
            {
                Id = 1,
                Name = "Побег из Шоушенка",
                Description = "Выдающаяся драма о силе таланта, важности дружбы, стремлении к свободе и Рите Хэйворт",
                Year = 1994,
                Poster = File.ReadAllBytes(@"Posters/Побег из Шоушенка.jpg"),
                ProducerSecondName = "Дарабонт",
                UserId = userId,
            },
                new Film
                {
                    Id = 2,
                    Name = "Зеленая миля",
                    Description = "В тюрьме для смертников появляется заключенный с божественным даром. Мистическая драма по роману Стивена Кинга",
                    Year = 1999,
                    Poster = File.ReadAllBytes(@"Posters/Зеленая миля.jpg"),
                    ProducerSecondName = "Дарабонт",
                    UserId = userId,
                },
                new Film
                {
                    Id = 3,
                    Name = "Властелин колец: Возвращение короля",
                    Description = "Арагорн штурмует Мордор, а Фродо устал бороться с чарами кольца. Эффектный финал саги, собравший 11 «Оскаров»",
                    Year = 2003,
                    Poster = File.ReadAllBytes(@"Posters/Властелин колец Возвращение короля.jpg"),
                    ProducerSecondName = "Джексон",
                    UserId = userId,
                },
                new Film
                {
                    Id = 4,
                    Name = "Властелин колец: Две крепости",
                    Description = "Голлум ведет хоббитов в Мордор, а великие армии готовятся к битве. Вторая часть трилогии, два «Оскаров»",
                    Year = 2002,
                    Poster = File.ReadAllBytes(@"Posters/Властелин колец Две крепости.jpg"),
                    ProducerSecondName = "Джексон",
                    UserId = userId,
                },
                new Film
                {
                    Id = 5,
                    Name = "Властелин колец: Братство Кольца",
                    Description = "Фродо Бэггинс отправляется спасать Средиземье. Первая часть культовой фэнтези-трилогии Питера Джексона",
                    Year = 2001,
                    Poster = File.ReadAllBytes(@"Posters/Властелин колец Братство Кольца.jpg"),
                    ProducerSecondName = "Джексон",
                    UserId = userId,
                },
                new Film
                {
                    Id = 6,
                    Name = "Интерстеллар",
                    Description = "Фантастический эпос про задыхающуюся Землю, космические полеты и парадоксы времени. «Оскар» за спецэффекты",
                    Year = 2014,
                    Poster = File.ReadAllBytes(@"Posters/Интерстеллар.jpg"),
                    ProducerSecondName = "Нолан",
                    UserId = userId,
                },
                new Film
                {
                    Id = 7,
                    Name = "Друзья: Воссоединение",
                    Description = "Спустя 17 лет друзья снова встречаются в квартире Моники. Спешел эпохального ситкома в формате ток-шоу",
                    Year = 2021,
                    Poster = File.ReadAllBytes(@"Posters/Друзья Воссоединение.jpg"),
                    ProducerSecondName = "Уинстон",
                    UserId = userId,
                },
                new Film
                {
                    Id = 8,
                    Name = "Форрест Гамп",
                    Description = "Полувековая история США глазами чудака из Алабамы. Абсолютная классика Роберта Земекиса с Томом Хэнксом",
                    Year = 1994,
                    Poster = File.ReadAllBytes(@"Posters/Форрест Гамп.jpg"),
                    ProducerSecondName = "Земекис",
                    UserId = user2Id,
                },
                new Film
                {
                    Id = 9,
                    Name = "Список Шиндлера",
                    Description = "История немецкого промышленника, спасшего тысячи жизней во время Холокоста. Драма Стивена Спилберга",
                    Year = 1993,
                    Poster = File.ReadAllBytes(@"Posters/Список Шиндлера.jpg"),
                    ProducerSecondName = "Спилберг",
                    UserId = user2Id,
                },
                new Film
                {
                    Id = 10,
                    Name = "Король Лев",
                    Description = "Львенок Симба бросает вызов дяде-убийце. Величественный саундтрек, рисованная анимация и шекспировский размах",
                    Year = 1994,
                    Poster = File.ReadAllBytes(@"Posters/Король Лев.jpg"),
                    ProducerSecondName = "Аллерс",
                    UserId = user2Id,
                },
                new Film
                {
                    Id = 11,
                    Name = "Иван Васильевич меняет профессию",
                    Description = "Иван Грозный отвечает на телефон, пока его тезка-пенсионер сидит на троне. Советский хит о липовом государе",
                    Year = 1973,
                    Poster = File.ReadAllBytes(@"Posters/Иван Васильевич меняет профессию.jpg"),
                    ProducerSecondName = "Гайдай",
                    UserId = user2Id,
                },
                new Film
                {
                    Id = 12,
                    Name = "Назад в будущее",
                    Description = "Безумный ученый и 17-летний оболтус тестируют машину времени и наводят шороху в 1950-х. Классика кинофантастики",
                    Year = 1985,
                    Poster = File.ReadAllBytes(@"Posters/Назад в будущее.jpg"),
                    ProducerSecondName = "Земекис",
                    UserId = user2Id,
                },
                new Film
                {
                    Id = 13,
                    Name = "Тайна Коко",
                    Description = "Юный Мигель, вопреки воле семьи, мечтает стать музыкантом. За помощью ему придется отправиться в мир мертвых",
                    Year = 2017,
                    Poster = File.ReadAllBytes(@"Posters/Тайна Коко.jpg"),
                    ProducerSecondName = "Анкрич",
                    UserId = userId,
                },
                new Film
                {
                    Id = 14,
                    Name = "Клаус",
                    Description = "",
                    Year = 2019,
                    Poster = File.ReadAllBytes(@"Posters/Клаус.jpg"),
                    ProducerSecondName = "Паблос",
                    UserId = user2Id,
                },
                new Film
                {
                    Id = 15,
                    Name = "Криминальное чтиво",
                    Description = "Знакомые типажи из подпольного мира заговорили по-новому. Самый влиятельный фильм 1990-х от Квентина Тарантино",
                    Year = 1994,
                    Poster = File.ReadAllBytes(@"Posters/Криминальное чтиво.jpg"),
                    ProducerSecondName = "Тарантино",
                    UserId = userId,
                },
                new Film
                {
                    Id = 16,
                    Name = "Карты, деньги, два ствола",
                    Description = "Дебют Гая Ричи — стильная комедия про ограбление с участием Винни Джонса и Джейсона Стэйтема",
                    Year = 1998,
                    Poster = File.ReadAllBytes(@"Posters/Карты, деньги, два ствола.jpg"),
                    ProducerSecondName = "Ричи",
                    UserId = userId,
                },
                new Film
                {
                    Id = 17,
                    Name = "ВАЛЛ·И",
                    Description = "Люди покинули Землю и оставили робота собирать за ними мусор. Экологический шедевр Pixar",
                    Year = 2008,
                    Poster = File.ReadAllBytes(@"Posters/ВАЛЛ·И.jpg"),
                    ProducerSecondName = "Стэнтон",
                    UserId = user2Id,
                },
                new Film
                {
                    Id = 18,
                    Name = "Начало",
                    Description = "Шпионаж фантастического уровня. С помощью сверхтехнологии герой Ди Каприо и его команда проникают в чужие сны",
                    Year = 1994,
                    Poster = File.ReadAllBytes(@"Posters/Начало.jpg"),
                    ProducerSecondName = "Нолан",
                    UserId = userId,
                },
                new Film
                {
                    Id = 19,
                    Name = "Унесённые призраками",
                    Description = "Девочка должна спасти своих родителей в мире духов. Шедевр Хаяо Миядзаки, фаворит анимационных рейтингов мира",
                    Year = 2001,
                    Poster = File.ReadAllBytes(@"Posters/Унесённые призраками.jpg"),
                    ProducerSecondName = "Миядзаки",
                    UserId = userId,
                },
                new Film
                {
                    Id = 20,
                    Name = "1+1",
                    Description = "Бывший зек возвращает вкус к жизни чопорному аристократу, прикованному к инвалидному креслу",
                    Year = 2011,
                    Poster = File.ReadAllBytes(@"Posters/1+1.jpg"),
                    ProducerSecondName = "Накаш",
                    UserId = user2Id,
                });
        }
    }
}
