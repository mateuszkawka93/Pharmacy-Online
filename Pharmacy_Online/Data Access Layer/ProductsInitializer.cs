using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pharmacy_Online.Migrations;
using Pharmacy_Online.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Pharmacy_Online.Data_Access_Layer
{
    public class ProductsInitializer : MigrateDatabaseToLatestVersion<ProductsContext, Configuration>
    {
        public static void SeedProductsData(ProductsContext context)
        {
            var category = new List<Category>
            {
                new Category()
                {
                    CategoryId = 1,
                    Description = "Na przeziębienie oraz grypę",
                    Name = "Przeziębienie i grypa"
                },
                new Category()
                {
                    CategoryId = 2,
                    Description = "Oczyszczanie i detoksykacja",
                    Name = "Oczyszczanie i odchudzanie"
                },
                new Category()
                {
                    CategoryId = 3,
                    Description = "Witaminy i minerały wysokiej jakości",
                    Name = "Witaminy i minerały"
                },
                new Category() {CategoryId = 4, Description = "Dla skóry i twarzy", Name = "Dermokosmetyki"},
                new Category()
                {
                    CategoryId = 5,
                    Description = "Leki przeciwbólowe i przeciwzapalne",
                    Name = "Przeciwbólowe i przeciwzapalne"
                },
                new Category()
                {
                    CategoryId = 6,
                    Description = "Wspomagające pracę serca oraz krążenie",
                    Name = "Serce i krążenie"
                },
                 new Category()
                {
                    CategoryId = 7,
                    Description = "Artykuły higieniczne dla dzieci oraz dorosłych",
                    Name = "Higiena"
                },
                 new Category()
                {
                    CategoryId = 8,
                    Description = "Suplementy diety dla osób aktywnych fizycznie",
                    Name = "Dla sportowców"
                },
                 new Category()
                {
                    CategoryId = 9,
                    Description = "Produkty dla niemowlaków i dzieci",
                    Name = "Żywienie dzieci"
                },
                 new Category()
                {
                    CategoryId = 10,
                    Description = "Artykuły spożyczwce bez dodatków substancji konserwujących",
                    Name = "Zdrowa żywność"
                },
                 new Category()
                {
                    CategoryId = 11,
                    Description = "Artykuły medyczne takie jak ciśnieniomierze czy glukometry",
                    Name = "Sprzęt medyczny"
                },
            };

            category.ForEach(c => context.Categories.AddOrUpdate(c));
            context.SaveChanges();

            var products = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    Name = "Gripex Hot Active Forte, 8 saszetek",
                    AddTime = DateTime.Now,
                    Bestseller = true,
                    CategoryId = 1,
                    Description = "Lek o działaniu przeciwgorączkowym, przeciwbólowym i udrażniającym nos.",
                    ImageFile = "gripex.png",
                    Price = 15,
                    Producer = "USP Zdrowie",
                    Recommendation = "krótkotrwałe łagodzenie objawów przeziębienia, grypy i zakażeń grypopodobnych, takich jak: gorączka, bóle głowy, gardła, bóle mięśniowe i kostno-stawowe oraz objawów obrzęku błony śluzowej nosa występujących w przeziębieniu, grypie.",
                    Ingredients = "1 saszetka zawiera: paracetamol 1000mg, kwas askorbowy 100mg, chlorowodorek fenylefryny 12,2mg oraz substancje pomocnicze: sacharoza, kwas cytrynowy, sodu cytrynian, acesulfan potasowy (E 950), aromat cytrynowy 875060, aromat cytrynowy 87A069, aromat cytrynowy 501.476/AP0504, aromat cytrynowy 875928, aspartam (E 951), żółcień chinolinowa (E 104)."
                },
                new Product()
                {
                    ProductId = 2,
                    Name = "Hepaslimin, tabletki 30 szt.",
                    AddTime = DateTime.Now,
                    Bestseller = true,
                    CategoryId = 1,
                    Description =
                        "Cholina jest składnikiem naturalnie występującym w organizmie. Wchodzi w skład fosfolipidów budujących błonę komórkową każdej żywej komórki. Pomaga w prawidłowym funkcjonowaniu wątroby. Wyciąg z ziela karczocha przyczynia się do prawidłowego funkcjonowania przewodu pokarmowego, wspiera detoksykację, stymuluje wydzielanie soków trawiennych oraz pomaga w utrzymaniu zdrowej wątroby. Przyczynia się do komfortu jelitowego. Wyciąg z korzenia cykorii wspomaga trawienie i pomaga w utrzymaniu zdrowej wątroby. Wyciąg z ostryżu długiego zapobiega gromadzeniu się tłuszczu. Mate pochodząca z liści ostrokrzewu paragwajskiego (Ilex paraguariensis) przyczynia się do rozkładu lipidów i pomaga w utrzymaniu prawidłowej masy ciała.",
                    ImageFile = "hepaslimin.png",
                    Price = 12,
                    Producer = "Aflofarm",
                    Recommendation = "składniki suplementu diety wspomagają: utrzymanie zdrowej wątroby, zachowanie prawidłowej masy ciała, prawidłowe trawienie.",
                    Ingredients = "celuloza (substancja wypełniająca), L-asparaginian L-ornityny, winian choliny, fosforan diwapniowy (substancja wypełniająca), wyciąg z liści mate, wyciąg z ziela karczocha, hydroksypropylometyloceluloza (substancja glazurująca), wyciąg z ostryżu długiego, wyciąg z korzenia cykorii, sole magnezowe kwasów tłuszczowych (substancja glazurująca), dwutlenek tytanu (barwnik), hydroksypropyloceluloza (substancja glazurująca), wosk pszczeli i wosk Carnauba (substancje glazurujące)."
                },
                new Product()
                {
                    ProductId = 3,
                    Name = "Gold-Luteina, tabletki 30 szt.",
                    AddTime = DateTime.Now,
                    Bestseller = false,
                    CategoryId = 3,
                    Description = "Gold-Luteina to suplement diety zawierający skoncentrowany olej rybi standaryzowany na zawartość kwasu dokozaheksaenowego (DHA) z grupy kwasów omega-3 oraz wysokiej jakości naturalną luteinę i zeaksantynę z aksamitki wyniosłej (Tagetes erecta L.) oraz cynk, a także witaminy A i E.\r\n \r\nKwas DHA jest głównym strukturalnym tłuszczem tkanek mózgowych, centralnego układu nerwowego, występującym w wysokiej koncentracji w błonach strukturalnych siatkówki oka, dzięki czemu przyczynia się do utrzymania prawidłowego widzenia i funkcjonowania narządu wzroku. Wykorzystując lipofilne właściwości luteiny i zeaksantyny, połączenie ich z olejem DHA stwarza optymalne warunki pozwalające na efektywną absorpcję w organizmie. Witamina E uczestniczy w ochronie komórek przez stresem oksydacyjnym. Cynk wraz z witaminą A odgrywającą kluczową rolę w procesie specjalizacji komórek oraz przyczyniają się do zachowania prawidłowego widzenia.",
                    ImageFile = "gold_luteina.png",
                    Price = 25,
                    Producer = "Olimp",
                    Recommendation = "suplementacja diety w składniki wpływające na zachowanie prawidłowego widzenia. ",
                    Ingredients = "skoncentrowany olej rybi bogaty w DHA; składniki peletek - [substancja wypełniająca - celuloza mikrokrystaliczna; luteina i zeaksantyna z aksamitki wyniosłej (Tagetes erecta L.), diglicynian cynku (chelat aminokwasowy cynku Albion); stabilizatory - hydroksypropylometyloceluloza, glikol polietylenowy], octan DL-alfa tokoferylu – witamina E, palmitynian retinylu – witamina A,  składnik otoczki - żelatyna."

                },
                new Product()
                {
                    ProductId = 4,
                    Name = "Ziaja Med Kuracja Lipidowa, płyn 400ml",
                    AddTime = DateTime.Now,
                    Bestseller = false,
                    CategoryId = 4,
                    Description = "Odżywcza emulsja lipidowa ukierunkowana na łagodzenie objawów skóry suchej takich jak: nadmierna wrażliwość, szorstkość, uczucie ściągnięcia i brak elastyczności. Zawiera biomimetyczne lipidy - ceramidy o skutecznym działaniu ochronno-regenerującym. Krem wzmacnia naturalną barierę lipidową skóry. Nawilża oraz zapobiega nadmiernej utracie wody. Łagodzi objawy suchości i wrażliwości naskórka, zapewniając skórze wysoką wartość odżywczo-regenerującą. Chroni przed agresywnymi działaniem czynników zewnętrznych.",
                    ImageFile = "ziajamed.png",
                    Price = 9.99m,
                    Producer = "Ziaja",
                    Recommendation = "skóra wrażliwa, alergiczna, sucha i bardzo sucha z zaburzeniami funkcji ochronnej skóry.",
                    Ingredients = "substancje czynne o charakterze hydro- i lipidowym: biomimotyczne lipidy - ceramidy 1,3,6ll, fitosfingozyna, NNKT z oleju oliwkowego, makadamia i bawełnianego, skwalan, cholesterol, beta-karoten z ekstraktu a nagietka, D-panthenol; substancje pomocnicze."
                },
                new Product()
                {
                    ProductId = 5,
                    Name = "Ibuprom Max, 400mg, 48 tab.",
                    AddTime = DateTime.Now,
                    Bestseller = true,
                    CategoryId = 5,
                    Description = "Lek o działaniu przeciwbólowym, przeciwgorączkowym, przeciwzapalnym",
                    ImageFile = "ibuprom.png",
                    Price = 13,
                    Producer = "USP Zdrowie",
                    Recommendation = "dolegliwości bólowe różnego pochodzenia o nasileniu słabym do umiarkowanego, w tym: bóle głowy, migrena, bóle zębów, bóle mięśniowe, bóle okolicy lędźwiowo-krzyżowej, bóle kostne i stawowe, nerwobóle; bolesne miesiączkowanie; gorączka (m.in. w przebiegu grypy, przeziębienia lub innych chorób zakaźnych).",
                    Ingredients = "1 tabletka zawiera: substancję czynną: ibuprofen 400mg oraz substancje pomocnicze: skład rdzenia: laktoza, powidon, skrobia kukurydziana, talk, kroskarmeloza sodowa, magnezu stearynian, krzemionka koloidalna bezwodna; skład otoczki: sacharoza, talk, skrobia kukurydziana, tytanu dwutlenek, wosk Carnauba, wosk biały."
                },
                new Product()
                {
                    ProductId = 6,
                    Name = "DIH, 500mg, tab. powlekane 60 szt.",
                    AddTime = DateTime.Now,
                    Bestseller = false,
                    CategoryId = 6,
                    Description = "Tabletki powlekane DIH zawierają diosminę, związek zaliczany do tzw. bioflawonoidów. DIH zwiększa napięcie naczyń żylnych oraz działa ochronnie na naczynia.",
                    ImageFile = "dih.png",
                    Price = 29,
                    Producer = "USP Zdrowie",
                    Recommendation = "Dih to lek w formie tabletek wskazany w zwalczaniu objawów towarzyszących niewydolności krążenia żylnego (bóle nóg, uczucie ciężkości) oraz w objawowym leczeniu żylaków odbytu. Preparat zawiera w składzie diosminę, substancję zaliczaną do bioflawonoidów, która wykazuje ochronny wpływ na naczynia krwionośne. ",
                    Ingredients = "1 tabletka zawiera: substancję czynną: zmikronizowaną diosminę 500mg oraz substancje pomocnicze: celuloza mikrokrystaliczna, powidon, karboksymetyloskrobia sodowa, magnezu stearynian, otoczka Opadry II 85F24220 Pink."
                },
            };

            products.ForEach(p => context.Products.AddOrUpdate(p));
            context.SaveChanges();
        }

        public static void SeedUsers(ProductsContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            const string name = "admin@bemini.pl";
            const string password = "zaq1@WSX";
            const string roleName = "Admin";

            var user = userManager.FindByName(name);

            if (user == null)
            {
                user = new ApplicationUser {UserName = name, Email = name, UserData = new UserData()};
                var result = userManager.Create(user, password);
            }
            //create admin role, if doesnt exist

            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleResult = roleManager.Create(role);
            }

            //add user to admin role

            var roleForUser = userManager.GetRoles(user.Id);
            if (!roleForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}