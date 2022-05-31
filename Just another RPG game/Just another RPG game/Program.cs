// обыкновенные переменные
int hp = 50, maxhp = 50, magicka = 0, maxmagicka = 0, def = 0, playerxp = 0, enemyhp = 0, enemymaxhp = 0, chlevel = 1, plusdmg = 0, enemydef = 0, dodgechance = 0
    , mydodgechance = 5, money = 10, upgradepoints = 0, pldodgechance = 10, enemystrMAX = 0, dodgenow = 0, nbcreature = 0, attpast = 0, gainxp = 0, hpregen = 0, magickaregen = 0, maxstat = 0;
byte playerstep = 0, killtoreturn = 0, killtocamp = 0, wordnumber = 0, attackdelay = 0, currentloc = 1;
string description = "", enemyname = "Im error";
bool skipintro = false, concentration = false, inhub = false, inbattle = false, oshparry = false;
// Массивы
string[] droppesttext = { "слизь", "грязная ветка", "кроличий глаз", "душа живучести", "ткань", "съедобная руда", "душа защиты", "плюводие", "радиокативная пыль", "душа пограничности", "гниль", "стекло", "механический глаз", "электроника", "пиал", "Смарт-Врайтер 2.3", "бездонный кошель"},
    potionname = { "целебное зелье", "зелье маны", "зелье уменьшения хитбокса", "зелье берсерка", "зелье кузнеца", "Технология Лизардов", "DEC-граната" },
    aname = { "Артефакт восстановления", "Артефакт накопления защиты", "Артефакт концентрации магии", "Артефакт Псевдолизарда", "Артефакт фортуны", "Артефакт героя" }, 
    aeffect = {"Восстанавливает 1/20 здоровья каждый ход. Шанс критического удара по вам возрастает в 3 раза","Защита от щита не пропадает после хода. После атаки противника, из количества защиты вычисляется нанесённый вам урон. Вы получаете на 40% меньше защиты от щита","Появляется 33% шанс удвоить используемое заклинание. 33% шанс, что заклинание не удастся воссоздать (с потерей хода и маны)",
    "3 ваших улучшаемых параметра (живучесть, сила, разум) получают 5 дополнительных очков. Вы не сможете получать опыт с монстров", "Шанс получить предмет с монстра уменьшается в 2 раза. Шанс получить к полученному предмету дополнительный увеличивается в 3 раза", 
    "В зависимости от самого высокого навыка вашего персонажа даёт пассивный бонус\nЖивучесть: Все ваши щитки каждый ход восстанавливают 10% прочности\nСила: Все ваши удары восстанавливают 10% вашего здоровья от нанесённого врагу урона\nРазум: Шанс макроразрыва всегда понижен вдвое"};
int[] concentratioon = { 0, 0, 0 }, stepsrem = { 0, 0, 0, }, items = { 4, 0, 0, 0, 0, 0, 0 }, craftitems = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, playerstat = { 0, 0, 50 },
    dropchance = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, magicduration = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, doggystat = { 0, 0, 0 },
slowingarray = { 0, 0 }, shieldhp = { 0, 0, 0, 0, 0 };
byte[] ballsteps = {0, 0, 0, 0, 0, 0, 0};
int[][] xpgains =
{
    new int[] {50, 50, 50, 50, 50},
    new int[] {50, 50, 50, 50, 50},
    new int[] {50, 50, 50, 50, 50},
    new int[] {50, 50, 50, 50, 50},
    new int[] {50, 50, 50, 50, 50},
    new int[] {0, 0},
    new int[] {1234}
};
bool[][] abilunlocks =
    {
    new bool[] { false, false, false, false, false, false},
    new bool[] { false, false, false, false, false, false},
    new bool[] { false, false, false, false, false, false, false}
}, dialogopt =
        {
    new bool[] {true, true, false, false, false, false, false, false, false, false, false, false, false, false},
    new bool[] {false, false, false, false, false, false, false, false, false, false, false, false, false, false},
     };
bool[] doyoufinditem = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, }, droppest = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
    dopotionfind = { true, false, false, false, false, false, false, false}, magiceffects = { false, false, false, false, false, false, false}, foundspell = { false, false, false, false, false, false }, fightwith = { false, false, false,},
    iknowaboutthat = { false, false, false, false, false, false }, hubreacts = { false, false, false, false, false, false, false, false, false, false, false, false};
// Единичные условия
bool doyouslowhis = false, enemynmoglas = false, slimereact = false, camptell = false, imadecrit = false;
bool[] artefact = { false, false, false, false, false, false }, findartefact = { false, false, false, false, false, false }, doublespells = { false, false, false, false, false, false };
// Режим разработчика
bool godmode = false, ultrahit = false;
gamestart();
void hub()
{
    if (!hubreacts[1])
    {
        Console.Clear();
        Console.WriteLine("После убийства очередной вражины земля под вашими ногами пропала");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Ощущение, что вы выпали из мира, вас одолевает эффект дежавю");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Действительно ли вы переживаете всё это в первый раз? Не так важно, вы ещё не раз вспомните всю свою жизнь, я уверен");
        Console.ReadLine();
    }
    if (!inhub)
    {
        Console.Clear();
        Console.WriteLine("Вы очутились в хабе!");
        Console.ReadLine();
        hp = maxhp;
        magicka = maxmagicka;
        inhub = true;
        hubreacts[5] = false;
        camptell = true;
    }
    if (!hubreacts[1])
    {
        string[] phrs = { "???: Привет. Тебя так долго не было, что-то случилось?", "???: Всмысле не знаешь кто я? Очередная потеря памяти значит... Я - Хэнк, скелет Хэнк" , "Хэнк: Я заведую этим местом и являюсь поставщиком ресурсов из других измерений, так как на нашей планете их почти не осталось",
        "Хэнк: Ты же являешься добытчиком этих ресурсов, а следственно воином, ведь большинство из них выбиваются путём крови. Понял?", "Хэнк: Вот и отлично. Можешь пока тут позависать, продать мне часть найденных вещей, либо прыгай в один из 4 порталов", "Хэнк: Не советую пока заходить во все кроме первого, там существа тебя явно щадить не будут, в отличии от поля"};
        for (int aa = 0; aa < phrs.Length; aa++)
        {
            Console.Clear();
            Console.WriteLine(phrs[aa]);
            Console.ReadLine();
        }
        hubreacts[1] = true;
    }
    Console.Clear();
    Console.WriteLine("Доступные действия: \n[1] Поговорить с Хэнком \n[2] Перейти к порталам\n[3] Лагерные действия");
    string playeraction = Console.ReadLine();
    if (playeraction == "1")
    {
        void dialogue()
        {
            Console.Clear();
            string[] wordlists = { "Потеря памяти", "Цели твоей работы", "Мехализарды", "Как выглядит камневод?", "Почему ты скелет?", "Кто заколдовал тебя?","Как появились священные духи?","Колония мехализардов", "Лизарды", "Кто управляет мехализардами", "Не могу попасть в резиденцию творцов", "Резиденция творцов", "Странный шарик", "Нечто - человеческий ребёнок\n"};
            string[][] fullwordlists =
            {
                new string[] {"Иногда при телепортации из-за несовершенства технологии атомы твоего тела меняются местами друг с другом.", "По этой же причине нейроны в твоей голове расформировываются, что приводит к плачевным обстоятельcтвам","К счастью, наша продвинутая медицина давно в состоянии лечить любые повреждения вызванные телепортацией"},
                new string[] {"Миру сейчас угрожает воинствующая армия мехализардов. Они поработили большую часть доступных измерений","То поле, что ты видовал, это не единственное спокойное местечко. Все места были спокойными до их прибытия","Теперь же они обосновали там свои колонии и потихоньку присматриваются к человеческой цивилизации"},
                new string[] {"Разумная механизированная армия ящеров. Их мозг заточён в большой капсуле, чтобы он не перерос черепную коробку","Руки их механизированны, а правый глаз каждого переоборудован под ротовое отверстие. Всю работу выполняет левый механический глаз","К счастью, в течении жизни они не развивают боевые навыки, в отличии от людей. Поэтому у нас есть шансы их побороть"},
                new string[] {"М, камневод? А ты его сам не видел чтоль?","Ну и названия понапридумывают. Представить как он выглядит не могу. Даже не спрашивай"},
                new string[] {"Неприятненькая история у меня была с этими порталами. После этого у меня начала стремительно гнить кожа", "Однако щепотка магии помогли моему телу существовать без этих оков. Однако последствия были, я перестал получать любые удовольствия", "Всё-же у нас священная миссия, а я, как её участник понимаю значимость своей роли. Мне и этого хватает"},
                new string[] {"Давненько жили 3 \"Священных духа\", как их принято называть. Они были способны контактировать с другими мирами", "Они учуяли в этом месте сильную магическую активность, которая в конечном итоге смогла питать эти порталы","Сейчас все 3 духа в гибернации, здесь. Они удерживают энергию этого места, не позволяя ей развеяться","Что до меня, эти же духи помогли мне с моей проблемой. Правда, как видишь, пришлось пожертвовать всей нервной системой",},
                new string[] {"Ну, не знаю. Было это давно, я уже и позабыл","Единственное что скажу, подобным им может стать кто хочет с достаточной силой духа, даже ты","Но этого никто не делает из-за стереотипов, страха людей перед неизвестным и прочего мракобесия", "Их отстранённость от нашего мира не делает их плохими или что-то такое, как думают. Надеюсь хоть ты здравомыслящий"},
                new string[] {"Весьма гиблое и неприятное местечко. Лизарды своей жадностью погубили всю жизнь занятых ими земель","Наша борьба не только за выживание рода людского и наше процветание, мы спасаем жизнь в других измерениях","Но уничтожив одну колонию ты никак на ситуаицию не повлияешь. Нужно искать пристанище самих Лизардов"},
                new string[] {"Мехализарды это лишь творение Лизардов. Лизарды, также называющие себя творцами, проживают в своей резиденции в небольшом богатом райончике", "Они враждебно настроены к людям, начиная с того, что мы тоже добываем ресурсы с других измерений, заканчивая тем небольшим остатком ресурсов нашего измерения"},
                new string[] {"Это неизвестно. В их головах очень малы проявления мышления, значит это лишь марионетки для дистанционного управления", "Тебе я думаю ещё предстоит об этом узнать. Если вывести мехализардов из под контроля, Лизарды сильно ослабнут и вероятно отстанут от нас"},
                new string[] {"Было весьма ожидаемо. У них стоят распознавательные системы, автоматически депортирующие неразрешённые объекты в другие измерения","Как видишь, в список разрешённый ты не входишь","Есть один выход: носить с собой артефакт псевдолизарда, излучающего сигналы, подобные сигналам Мехализардов"},
                new string[] {"Так, ты побывал в резиденции? Ты очень близок, но всё ещё не у цели", "По информации, что я слышал, по настоящему убить Лизардов невозможно. Их разум мгновенно перенесётся в их компьютерную базу, где будет загружен в новое искуственно выращенное тело", "Зато ты можешь понабирать у них ценных вещичек. С их технологическим развитием, думаю, мы можем позаимствовать у них некоторые разработки на будущее"},
                new string[] {"Говоришь, эта безделушка создаёт ещё один портал вблизи с арками?", "Подозреваю это портал в ещё одно их пристанище, либо куда похуже", "Если не готов к худшему, не советую пока входить, я серьёзно", "Хоть мы и не знаем, что там, риск должен быть минимизирован"},
                new string[] {"Чего? Какой нечто, какой ребёнок? Тот, с которым ты сражался по ту сторону?", "Если ты не бредишь, они реально звери. Не знаю, у кого конкретно они его украли, но мне кажется они явно могли обойтись без таких жертв", "И да, не вини себя. Раз говоришь, он был уже не совсем человеком по разуму, вся ответственность лежит на Лизардах", "Смерть одного калеки лучше, чем смерти сотен людей от голода или самих Лизардов"},
            };
            Console.WriteLine("[e] Выход\n[1] Торговля");
            for (int aa = 0; aa < dialogopt[0].Length; aa++)
            {
                if (aa > 0 && dialogopt[0][aa - 1])
                    Console.WriteLine();
                if(dialogopt[0][aa])
                Console.Write("[" + (aa + 2) + "] " + wordlists[aa]);
                if (dialogopt[1][aa])
                    Console.Write(" (Прослушано)");
            }
            playeraction = Console.ReadLine();
            bool isNum = int.TryParse(playeraction, out int choice);
            if (isNum)
            {
                if (playeraction == "1")
                    trade();
                if ((choice - 1) <= dialogopt[0].Length && choice > 1)
                {
                    if (dialogopt[0][choice - 2])
                    {
                        for (int aa = 0; aa < fullwordlists[choice - 2].Length; aa++)
                        {
                            Console.Clear();
                            Console.WriteLine("Хэнк: " + fullwordlists[choice - 2][aa]);
                            Console.ReadLine();
                        }
                        dialogopt[1][choice - 2] = true;
                        if (choice == 3)
                            dialogopt[0][2] = true;
                        if (choice == 6)
                            dialogopt[0][5] = true;
                        if (choice == 7)
                            dialogopt[0][6] = true;
                        if (choice == 9)
                            dialogopt[0][8] = true;
                        if (choice == 10)
                            dialogopt[0][9] = true;
                        dialogue();
                    }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Выбранного варианта не существует");
                            Console.ReadLine();
                            dialogue();
                        }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Выбранного варианта не существует");
                    Console.ReadLine();
                    dialogue();
                }
                void trade()
                {
                    Console.Clear();
                    int[] prices = {10, 8, 12, 15, 13, 17, 20, 14, 20, 23, 5, 14, 40, 70, 35, 65, 50 };
                    Console.WriteLine("Ваши деньги: " + money + " сребреников\nВаши действия:\n[e] Выход\n[z] Продать всё\n[x] Продать всё, кроме душ\n[c] Продать только души\n[v] Создание артефактов\n[b] Покупка расходников\n\nПродажа по отдельности:");
                    for (int aa = 0; aa < droppesttext.Length; aa++)
                    {
                        if (doyoufinditem[aa])
                            Console.WriteLine("[" + (aa + 1) + "] " + droppesttext[aa] + "(" + craftitems[aa] + ") | " + prices[aa] + " сребреников");
                    }
                    playeraction = Console.ReadLine();
                    bool isNum = int.TryParse(playeraction, out int choice1);
                    choice = choice1 - 1;
                    void confirm()
                    {
                        Console.Clear();
                        Console.WriteLine("Вы действительно хотите это сделать?\n     y- Согласие   n- Опровержение");
                        playeraction = Console.ReadLine();
                        if (playeraction != "y" && playeraction != "Y")
                            trade();
                    }
                    if (isNum && choice >= 0 && choice < droppesttext.Length)
                    {
                        if (doyoufinditem[choice])
                        {
                            Console.Clear();
                            Console.WriteLine("Укажите желаемое число вещей на продажу, или выйдите, введя Е\n1 " + droppesttext[choice] + " - " + prices[choice] + " сребреников");
                            playeraction = Console.ReadLine();
                            isNum = int.TryParse(playeraction, out int choice2);
                            if (isNum && choice2 >= 0 && choice2 <= craftitems[choice])
                            {
                                money += prices[choice] * choice2;
                                craftitems[choice] -= choice2;
                                trade();
                            }
                            else if (!isNum)
                                trade();
                            else if (choice2 < 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Хэнк: Ооой, не не не. Я не продаю тебе эти предметы. Ты здесь поставщик, а не потребитель");
                                Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Хэнк: Если потратить деньги хочешь, закупись зельями, у меня их предостаточно");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("У вас не хватает предметов для продажи");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Такого товара не существует");
                            Console.ReadLine();
                        }
                    }
                    else if (isNum)
                    {
                        Console.Clear();
                        Console.WriteLine("Такого товара не существует");
                        Console.ReadLine();
                    }    
                    else if (!isNum)
                    {
                        if (playeraction == "z" || playeraction == "Z")
                        {
                            confirm();
                            for (int aa = 0; aa < droppesttext.Length; aa++)
                            {
                                money += prices[aa] * craftitems[aa];
                                craftitems[aa] = 0;
                            }
                        }
                        else if (playeraction == "x" || playeraction == "X")
                        {
                            confirm();
                            for (int aa = 0; aa < droppesttext.Length; aa++)
                            {
                                if (aa != 3 && aa != 6)
                                {
                                    money += prices[aa] * craftitems[aa];
                                    craftitems[aa] = 0;
                                }
                            }
                        }
                        else if (playeraction == "c" || playeraction == "C")
                        {
                            confirm();
                            money += prices[3] * craftitems[3];
                            craftitems[3] = 0;
                            money += prices[6] * craftitems[6];
                            craftitems[6] = 0;
                        }
                        else if (playeraction == "v" || playeraction == "V")
                        {
                            craftarts();
                            void craftarts()
                            {
                                string[] myphr = { "Хэнк: Я вижу ты насобирал этих таблеток, так?", "Хэнк: Знаю, удивительно, но у них есть очень неплохое практическое применение", "Хэнк: Каждый тип из них хранит в себе магическую энергию определённого типа", "Хэнк: Собрав достаточно, их можно спрессовать и получить часть артефакта", "Хэнк: За вторую часть не переживай, она дешёвая и я тебе сам её предоставлю. Всё-таки ты мой сотрудник", "Хэнк: Эти штуки не обязательно носить по одной, но сила каждой из них забирает у тебя что-то и даёт взамен, так-что будь готов" };
                                for (int aa = 0; !hubreacts[8]; aa++)
                                {
                                    Console.Clear();
                                    Console.WriteLine(myphr[aa]);
                                    Console.ReadLine();
                                    if (aa == 5)
                                        hubreacts[8] = true;
                                }
                                Console.Clear();
                                Console.WriteLine("Возможные артефакты:");
                                for (int aa = 0; (aa + 1) < aname.Length; aa++)
                                {
                                    if (!findartefact[aa])
                                        Console.WriteLine("[" + (aa + 1) + "]" + aname[aa] + " (Не создан)");
                                    else
                                        Console.WriteLine("[" + (aa + 1) + "]" + aname[aa] + " (Уже в наличии)");
                                }
                                Console.WriteLine("[e] Выход");
                                playeraction = Console.ReadLine();
                                bool isNum = int.TryParse(playeraction, out int choice);
                                if (choice > 0 && choice < 6)
                                {
                                    if (findartefact[choice - 1])
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Артефакт уже создан");
                                        Console.ReadLine();
                                        craftarts();
                                    }
                                    else
                                    {
                                        string[] padej = { "душ живучести", "душ защиты", "душ пограничности", "электроники", "фракталиумов" };
                                        Console.Clear();
                                        Console.WriteLine("Эффект артефакта: " + aeffect[choice - 1] + "\nВы действительно хотите создать " + aname[choice - 1] + "? \n          y - Да          n - нет\nЦена артефакта - 10 " + padej[choice - 1]);
                                        playeraction = Console.ReadLine();
                                        if (playeraction == "y" || playeraction == "Y")
                                        {
                                            if (choice == 1 && craftitems[3] > 9)
                                                craftitems[3] -= 10;
                                            else if (choice == 2 && craftitems[6] > 9)
                                                craftitems[6] -= 10;
                                            else
                                            {
                                                Console.Clear();
                                                if (choice != 4)
                                                Console.WriteLine("У вас не хватает " + padej[choice - 1] + " для создания артефакта");
                                                Console.ReadLine();
                                                craftarts();
                                            }
                                            findartefact[choice - 1] = true;
                                        }
                                        craftarts();
                                    }
                                }
                                else if (isNum)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Данного артефакта не существует");
                                    Console.ReadLine();
                                    craftarts();
                                }
                                else
                                    trade();
                            }
                        }
                        else if (playeraction == "b" || playeraction == "B")
                        {
                            buypotion();
                            void buypotion()
                            {
                                int[] potionprice = { 50, 50, 100, 100, 100, 250, 250};
                                Console.Clear();
                                Console.WriteLine("Покупка расходников:");
                                for (byte aaa = 0; aaa < potionname.Length; aaa++)
                                    Console.WriteLine("[" + (aaa + 1) + "] " + potionname[aaa] + " - " + potionprice[aaa] + " сребреников (сейчас у вас " + items[aaa] + ")");
                                Console.WriteLine("[e] Выход");
                                playeraction = Console.ReadLine();
                                isNum = int.TryParse(playeraction, out int choice);
                                if (choice > 0 && choice < (potionname.Length + 1))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Укажите желаемое число зелий, или выйдите, введя Е\nЦена 1 зелья - " + potionprice[choice - 1]);
                                    playeraction = Console.ReadLine();
                                    isNum = int.TryParse(playeraction, out choice1);
                                    if (isNum && choice1 >= 0)
                                    {
                                        if (money >= potionprice[choice - 1] * choice1)
                                        {
                                            money -= potionprice[choice - 1] * choice1;
                                            items[choice - 1] += choice1;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("У вас не хватает денег для покупки");
                                            Console.ReadLine();
                                        }
                                        buypotion();
                                    }
                                    else if (choice1 < 0)
                                    {
                                        Console.Clear();
                                        if (choice == 5)
                                            Console.WriteLine("Хэнк: Нее, дядя. Выкупать эти штуки не в моём стиле. Я и так тебе их по заниженным ценам отдаю :)");
                                        else
                                            Console.WriteLine("Хэнк: Нее, дядя. Выкупать зелья не в моём стиле. Я и так тебе их по заниженным ценам отдаю :)");
                                        Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine("Хэнк: А если заработать хочешь, я скуплю весь твой хлам с монстров");
                                        Console.ReadLine();
                                        buypotion();
                                    }
                                    else
                                        buypotion();
                                }
                            }
                        }
                        else
                            dialogue();
                    }
                    trade();
                }
            }   
            else
                hub();
        }
        dialogue();
    }
    else if (playeraction == "2")
    {
        Console.Clear();
        Console.WriteLine("Выберите нужное измерение\n[e] Вернуться\n[1] Бесконечное поле\n[2] Побережье\n[3] Ноющая пустошь\n[4] Колония Мехализардов");
        if (hubreacts[3])
        {
            Console.WriteLine("[5] Резиденция творцов");
            if (hubreacts[4] && !dialogopt[0][13])
                Console.WriteLine("[6] ????");
        }
        Console.WriteLine("[e] Выход");
        playeraction = Console.ReadLine();
        bool isNum = int.TryParse(playeraction, out int choice);
        if (isNum)
        {
            if (choice > 0 && choice < 6 || choice > 0 && choice < 7 && hubreacts[3])
            {
                string[] choicevar = { "бесконечном поле!","побережье!","серой ноющей пустоши!", "окраинах колонии Мехализардов!", "центральной резиденции творцов!", "0(*^)&(%&*%&^&(%" };
                inhub = false;
                currentloc = Convert.ToByte(choice);
                camptell = false;
                Console.Clear();
                Console.WriteLine("Вы ступили в портал. Миллионы километров пустоты проносятся вокруг вас. Вы оказываетесь на " + choicevar[choice - 1]);
                Console.ReadLine();
                if (choice == 6 && hubreacts[4] && !dialogopt[0][13])
                {
                    for (int aa = 0; aa < 50000; aa++)
                        Console.Write("?*?);№?;№%:*?*(%?");
                    hubreacts[5] = true;
                    {
                        if (!hubreacts[6])
                        {
                            string[] wordlist =
                            {
            "Добро пожаловать в Just another RPG game. Нажмите #@)$(*%#@)%$*(#)@$*)(@#*$@#($)*@#)$(@#*$()#*@()$*@#)$*(, чтобы продолжить.",
            "Вы проснулись посреди огромного поля. Солнышко светит, цветочки благоухают.",
            "Вы решились открыть глаза. Но кровь казалась слишком горячей. Вы плавитесь изнутри?",
        };
                            for (int aa = 0; aa < wordlist.Length; aa++)
                            {
                                Console.Clear();
                                Console.WriteLine(wordlist[aa]);
                                Console.ReadLine();
                            }
                            for (int aa = 0; aa < 50000; aa++)
                            {
                                Console.Write("?*?);№?;№%:*?*(%?");
                            }
                            string[] wordlist2 =
                            {
            "Нет, вы ничего этого не видели.",
            "Вы просыпаетесь. Мысли, посещавшие вас только что кажутся настоящим безумием, не правда ли?",
            "Вы очутились в прохладном помещении с работающими вокруг индустриальными машинами. Вы явно вне настоящего времени",
            "Обернувшись вы видите подвешенный мешок в форме тела, покрытый металлическими пластинами. \nТорчащая от направления рта трубка и динамик на лбу сигнализируют о том, что это уже давно не человек.",
            "Нечто: Знаешь ли ты, что такое настоящая боль? Я да.",
            "Нечто: Был вынужден находиться здесь десятки лет и контролировать разум этих болванов. Автоматизация чёртова",
            "Нечто: Я бы с радостью дал себя на растерзанье тебе, но боюсь система защиты приготовленная для меня будет против",
            "Голос снаружи: Обнаружены противоречивые мысли. Немедленно сменить направление мышления",
            "Нечто: Ты, человеческое существо, всего-лишь жалкое биологическое порождение. Ты уничтожил десятки моих последователей",
            "Нечто: Смерть - лучший исход для тебя. И я не упущу возможность сделать тебе как можно лучше."
        };
                            for (int aa = 0; aa < wordlist2.Length; aa++)
                            {
                                Console.Clear();
                                Console.WriteLine(wordlist2[aa]);
                                Console.ReadLine();
                            }

                            fightwith[0] = true;
                        }
                        else
                        {
                            for (int aa = 0; aa < 5000; aa++)
                                Console.Write("?*?);№?;№%:*?*(%?");
                            Console.Clear();
                            Console.WriteLine("Нечто: Ну что, начнём веселье?");
                            Console.ReadLine();
                        }
                        wordnumber = 0;
                        hp = maxhp;
                        hubreacts[9] = false;
                        theSomething();
                    }
                }
                outofbattle();
            }
        }
        else hub();
    }
    else if (playeraction == "3")
        timetocamp();
    hub();

}
void options()
{
    Console.Clear();
    string skipintr0;
    if (skipintro) { skipintr0 = "включено"; } else { skipintr0 = "выключено"; }
    Console.WriteLine("[1] Пропуск вступительного текста - " + skipintr0);
    Console.WriteLine("[e] Выход");
    string playeraction = Console.ReadLine();
    if (playeraction == "1" && skipintro)
    {
        skipintro = false;
        options();
    }
    else if (playeraction == "1" && !skipintro)
    {
        skipintro = true;
        options();
    }
}
void playerinventory()
{
    Console.Clear();
    Console.WriteLine("Ваш инвентарь: \n[1] зелья и расходники\n[2] список артефактов\n[3] ресурсы для крафта\n[e] выйти из меню инвентаря");
    string playeraction = Console.ReadLine();
    if (playeraction == "1")
    {
            Console.Clear();
            Console.WriteLine("Ваши предметы: ");
            for (int aa = 0; aa < potionname.Length; aa++)
            {
            if (dopotionfind[aa])
                Console.WriteLine("[" + (aa + 1) + "] " + potionname[aa] + "(" + items[aa] + ")");
            }
            Console.WriteLine("[e] выход");
            playeraction = Console.ReadLine();
            bool isNum = int.TryParse(playeraction, out int choice);
            if (isNum)
            {
                if (choice > 0 && choice < 8)
                {
                    if (dopotionfind[choice - 1])
                    {
                        byte ch1 = Convert.ToByte(choice - 1);
                        hpregen = 30 + chlevel * 2;
                        magickaregen = Convert.ToInt32(20 + (int)(chlevel) * 1.5);
                    string[] potioneffects =
{
                         "восстановление " + (hpregen) + " хп",
                         "восстановление " + (magickaregen) + " маны",
                         "увеличение шанса уклонения в 3 раза на 3 хода",
                         "увеличение урона в полтара раза и увеличение шанса крита в 3 раза в течении 3 ходов",
                         "Починка брони в течении 3 ходов в 2,5 раза эффективнее",
                         "В течении 3 ходов параметры персонажа никак не будут меняться",
                         "DEC (разложение) граната создаёт облако газа вокруг противника, действующее 3 хода. С каждым ходом наносит в 2 раза больше урона, начиная с " + (5 + chlevel / 3) + "\nЭффект не складывается"
};
                    Console.Clear();
                        Console.WriteLine("Эффект применения: " + potioneffects[ch1] + "\nВы действительно хотите использовать " + potionname[ch1] + "? \n          y - Да          n - нет");
                        playeraction = Console.ReadLine();
                        if (playeraction == "y" && items[ch1] > 0 || playeraction == "Y" && items[ch1] > 0)
                        {
                            Console.Clear();
                            if (ch1 == 0)
                            {
                                if (magicduration[8] <= 0)
                                    hp += hpregen;
                                Console.WriteLine("Восстановлено " + (hpregen) + " хп");
                                Console.ReadLine();
                            }
                            else if (ch1 == 1)
                            {
                                if (magicduration[8] <= 0)
                                    magicka += magickaregen;
                                Console.WriteLine("Восстановлено " + magickaregen + " маны");
                                Console.ReadLine();
                            }
                            else if (ch1 == 2)
                            {
                                magicduration[6] += 3;
                                Console.WriteLine("Ваше тело стремительно уменьшается!");
                                Console.ReadLine();
                            }
                            else if (ch1 == 3)
                            {
                                magicduration[7] += 3;
                                Console.WriteLine("Вас переполняет ярость!");
                                Console.ReadLine();
                            }
                            else if (ch1 == 4)
                            {
                            magicduration[9] += 3;
                            Console.WriteLine("Ваше мастерство неумолимо растёт!");
                            Console.ReadLine();
                        }
                        else if (ch1 == 5)
                        {
                            magicduration[8] += 3;
                            Console.WriteLine("Вы чувствуете стагнацию");
                            Console.ReadLine();
                        }
                        else if (ch1 == 6)
                        {
                            magicduration[10] = 3;
                            Console.WriteLine("Вы со всей силы бросаете гранату во врага");
                            Console.ReadLine();
                        }
                        items[ch1] -= 1;
                        }
                        else if (playeraction == "y" && items[ch1] <= 0 || playeraction == "Y" && items[ch1] <= 0)
                        {
                            Console.Clear();
                        string[] notenoughpotions =
                        {
                            "целебных зелий", "зелий маны", "зелий маленького хитбокса", "зелий берсерка", "зелий кузнеца", "технологий лизардов", "DEC-гранат"
                        };
                            Console.WriteLine("У вас не хватает " + notenoughpotions[ch1] + " для использования");
                            Console.ReadLine();
                        }

                        playerinventory();
                    }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Данного расходника не существует");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Данного расходника не существует");
                Console.ReadLine();
            }
            }
                playerinventory();
    }
    else if (playeraction == "2")
    {
        artefactmenu();
        void artefactmenu()
        {
            string playeraction;
            Console.Clear();
            Console.WriteLine("Ваши артефакты:");
            for (int aa = 0; aa < 6; aa++)
            {
                if (!findartefact[aa])
                    Console.WriteLine("[" + (aa + 1) + "] " + "????");
                else
                {
                    string boool;
                    if (artefact[aa])
                        boool = " (экипирован)";
                    else
                        boool = " (не экипирован)";
                    Console.WriteLine("[" + (aa + 1) + "] " + aname[aa] + boool);
                }
            }
            Console.WriteLine("[e] выход");
            string pplayeraction = Console.ReadLine();
            int choice;
            bool isNum = int.TryParse(pplayeraction, out choice);
            string[] artefacts = { "восстановления", "накопления защиты", "концентрации магии", "псевдолизарда", "Фортуны", "Героя" };
            int vous = 0;
            if (isNum)
                vous = choice - 1;
            if (choice > 0 && choice <= 6)
            {
                if (!artefact[vous] && findartefact[vous])
                    deletelsif();
                else if (artefact[vous] && findartefact[vous])
                    deletelse();
                else if (!findartefact[vous])
                {
                    Console.Clear();
                    Console.WriteLine("Вы ещё не нашли этот артефакт");
                    Console.ReadLine();
                    artefactmenu();
                }
            }
            else if (isNum)
            {
                Console.Clear();
                Console.WriteLine("Данного артефакта не существует");
                Console.ReadLine();
                artefactmenu();
            }
            else if (!isNum)
                playerinventory();
            void deletelse()
            {
                Console.Clear();
                Console.WriteLine("Эффект артефакта: " + aeffect[vous] + "\nВы действительно хотите снять артефакт " + artefacts[vous] + "?\n          y - Да          n - нет");
                playeraction = Console.ReadLine();
                if (playeraction == "y" || playeraction == "Y")
                {
                    artefact[vous] = false;
                    if (vous == 3)
                        playerstat[0] -= 5; playerstat[1] -= 5; playerstat[2] -= 5;
                    artefactmenu();
                }
                else
                    artefactmenu();
            }
            void deletelsif()
            {
                Console.Clear();
                Console.WriteLine("Эффект артефакта: " + aeffect[vous] + "\nВы действительно хотите экипировать артефакт " + artefacts[vous] + "?\n          y - Да          n - нет");
                playeraction = Console.ReadLine();
                if (playeraction == "y" || playeraction == "Y")
                {
                    artefact[vous] = true;
                    if (vous == 3)
                        playerstat[0] += 5; playerstat[1] += 5; playerstat[2] += 5;
                    artefactmenu();
                }
                else
                    artefactmenu();
            }
        }
    }
    else if (playeraction == "3")
    {
        lootmenu();
        void lootmenu()
        {
            string[] itemdesc = { "Концентрация поливинилацетата, немного желатина и чуточка магии", "Не знаю зачем она нужна, из неё даже не сделать кирку", "Вам повезло, что это не лапка. Ваша удача и так на сомнительном уровне",
                "Почему душа выглядит как таблетка из пластика? Не задавай вопросов. Можешь притвориться хранителем душ, мало-ли", "Качественная ткань на вид. Но так как ты неуч, ты не узнаешь, из чего она состоит", "Перед употреблением хорошенько обжарить или промыть",
                "Эта выглядит, как обезбаливающее. Можно было бы использовать, если бы это не была гомеопатия", "Ошибка загрузки: Медиафайл не может быть воспроизведён", "Пыль былой сверхдержавы, погрязшей в неправильных ценностях... Но только в ваших мечтах",
                "Вы её не видите, а она есть. Никто никогда не узнает, что вы кого-то ей отравили", "Рыба гниёт с головы. Как жаль, что вы человек", "Что лучше, быть стеклянной пушкой или сбалансированным воином? Решать не вам однако", "Это будет ужасная ночь...",
                "3 провода, железная пластина и вуаля!", "У Лизардов принято, что пиал приносит удачу. Верите вы в это или нет, камешек весьма дорогой", "Металлический белый лист с записями на неизвестном языке. Когда вы думаете, эти записи дополняются", "Вглядывайся внутрь получше, быть может и разглядишь своё социальное положение"};
            Console.Clear();
            int aa = 0;
            int ifind = 0;
            int allitems = 0;
            while (aa < doyoufinditem.Length)
            {
                if (doyoufinditem[aa])
                    ifind++;
                allitems++;
                aa++;
            }
            Console.WriteLine("Найдено предметов: " + "(" + ifind + "/" + allitems + ")");
            aa = 0;
            bool youhaveanithing = false;
            while (aa < doyoufinditem.Length)
            {
                if (doyoufinditem[aa])
                {
                    Console.WriteLine("[" + (aa + 1) + "] " + droppesttext[aa] + " (" + craftitems[aa] + ")");
                    youhaveanithing = true;
                }
                aa++;
                allitems++;
            }
            if (!youhaveanithing)
                Console.WriteLine("Ничего нет :(");
            Console.WriteLine("[e] выход");
            string pplayeraction = Console.ReadLine();
            int choice;
            bool isNum = int.TryParse(pplayeraction, out choice);
            if (isNum)
            {
                Console.Clear();
                try
                {
                    if (doyoufinditem[choice - 1])
                    {
                        Console.WriteLine(itemdesc[choice - 1]);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Предмета под данным номером не существует");
                        Console.ReadLine();
                    }
                    lootmenu();
                }
                catch
                {
                    Console.WriteLine("Предмета под данным номером не существует");
                    Console.ReadLine();
                }
                lootmenu();
            }
            else
                playerinventory();
        }
    }
    else
    {
        if (!camptell)
            playermove();
        else
            timetocamp();
    }    
}
void enemystep()
{
    if (!concentration && concentratioon[0] > 0)
    {
        playerstat[2] -= concentratioon[0];
        concentratioon[0] = 0;
    }
    pldodgechance = 10 + playerstat[2] / 2;
    // действие магии
    if (magicduration[8] <= 0)
        if (magiceffects[1] && magicduration[1] > 0)
        {
        hp += playerstat[2];
        magicduration[1]--;
        if (doublespells[1])
            hp += 5 + playerstat[2] / 3;
        if (magicduration[1] > 0)
            magiceffects[1] = false;
        }
    if (magicduration[8] <= 0)
        if (magiceffects[2] && magicduration[2] > 0)
        {
        if (doublespells[1])
        def += playerstat[2];
        def += playerstat[2];
        }
    if (magiceffects[3] && magicduration[3] > 0)
    {
        doggystat[0] = 15 + playerstat[2];
        doggystat[1] = 5 + playerstat[2] / 2;
        doggystat[2] = 1;
        magiceffects[3] = false;
    }    
    if (magiceffects[4] && magicduration [4] > 0)
    {
        if (!doyouslowhis)
        slowingarray[1] = attackdelay;
        doyouslowhis = true;
        magiceffects[4] = false;
        attackdelay += 1;
        if (doublespells[4])
            attackdelay += 1;
    }
    if (magiceffects[6] && magicduration[6] > 0)
    {
        if (!doyouslowhis)
            slowingarray[1] = attackdelay;
        doyouslowhis = true;

    }
    //остальное
    if (magicka > maxmagicka)
        magicka = maxmagicka;
    if (!enemynmoglas)
    {
        Console.Clear();
        Console.WriteLine("В сражение вступает " + enemyname + "!");
        gainxp = xpgains[xpgains[5][0]][xpgains[5][1]];
        enemynmoglas = true;
        Console.ReadLine();
    }
    if (playerstep >= attackdelay && enemyhp > 0)
    {
        playerstat[2] -= concentratioon[2];
        concentratioon[2] = 0;
        concentration = false;
        concentratioon[1] = 0;
        if (magicduration[6] > 0)
        {
            pldodgechance *= 3;
            magicduration[6]--;
        }
        if (magiceffects[5] && magicduration[5] > 0)
        {
            pldodgechance = 100;
            if (doublespells[5])
            {
                magicduration[5]++;
                doublespells[5] = false;
            }
            magicduration[5]--;
        }
        if (stepsrem[0] > 0)
            stepsrem[0]--;
        if (fightwith[0] && !hubreacts[9] && enemyhp <= (enemymaxhp / 2))
        {
            string[] words = { "Механический голос сверху: Обнаружены серьёзные травмы. Требуется немедленное медицинское вмешательство. Ввожу медикаменты", "Здоровье Нечто восстановлено до предела", "Нечто: Уничтожая меня, ты губишь целую цивилизацию. После того, как ты убил множество невинных рабочих и беззащитных существ, как ты смеешь называть себя человеком?", "Нечто: Нам не понять тебя, грязный богохульник. Мы не опустимся до твоего уровня" };
            enemyhp = enemymaxhp;
            for (int aa = 0; aa < words.Length; aa++)
            {
                Console.Clear();
                Console.WriteLine(words[aa]);
                Console.ReadLine();
            }
            hubreacts[9] = true;
        }
        Console.Clear();
        Random rnd = new();
        int parry = 0;
        int attValue = rnd.Next((enemystrMAX / 2), (enemystrMAX));
        int minushp = attValue;
        Random rnd2 = new();
        int dopldodge = rnd2.Next(101);
        if (fightwith[0] && !hubreacts[10] && enemyhp <= (enemymaxhp / 5) && hubreacts[9])
        {
            string[] words = {"Механический голос сверху: Ведущий при смерти. Требуется незамедлительное критическое усиление защиты", "Нечто: Дитя, одумайся. Просто так, убить бога, из-за своей глупой алчности? У тебя ещё есть шанс искупить грехи. Брось оружие, иначе..."};
            for (int aa = 0; aa < words.Length; aa++)
            {
                Console.Clear();
                Console.WriteLine(words[aa]);
                Console.ReadLine();
            }
            hubreacts[10] = true;
        }
        if (attpast > 0)
        {

            Console.WriteLine(enemyname + " получает " + attpast + " урона от вашей крови");
            attpast = 0;
            if (enemyhp <= 0)
            {
                Console.ReadLine();
                attpast = 0;
                Death();
            }     
        }
        void dodef()
        {
            if (def > attValue)
                parry += attValue;
            else if (def < attValue)
                parry += def;
        }
        int pcrit = 0;
        if (abilunlocks[0][0] && oshparry)
        {
            Random rnd101 = new();
            pcrit = rnd101.Next(101);
                dodef();
            if (pcrit <= 10 + (playerstat[0] / 4) && abilunlocks[0][2])
                parry += parry / 2;
        }
        if (magiceffects[2] && magicduration[2] > 0)
        {
            dodef();
            if (doublespells[2])
                dodef();
            magicduration[2]--;
            if (magicduration[2] <= 0)
                magiceffects[2] = false;
        }
        if (abilunlocks[0][0] && def > attValue && oshparry)
            parry += attValue;
        else if (abilunlocks[0][0] && def < attValue && oshparry)
            parry += def;
        if (dopldodge <= pldodgechance)
        {
            minushp = 0;
            Console.WriteLine(enemyname + " промахнулся");
        }
        if (godmode)
            minushp = 0;
        if (fightwith[2])
        {
            int minuss = 200 - def;
            double plus = 0;
            for (int aa = 0; (aa * 10 + 9) < playerstat[0]; aa++)
            {   
                if (shieldhp[aa] > 0)
                {
                    plus += shieldhp[aa];
                    shieldhp[aa] = 0;
                }
            }
            minuss -= (int)plus;
            if (minuss < 0)
                minuss = 0;
            enemyhp = 0;
            Console.Clear();
            Console.WriteLine("Транспортный дрон: Нахожусь в экстренной ситуации. Вхождение в режим камикадзе...");
            Console.WriteLine("Взрыв наносит вам " + minuss + " урона");
            Console.ReadLine();
            if (magicduration[8] <= 0)
            hp -= minuss;
            if (hp <= 0)
            {
                Console.Clear();
                Console.WriteLine("Вы умерли. Но вы всё ещё способны чувствовать");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Вы вспоминаете свежий воздух полей, палящее солнце пляжа...");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Однако все эти чувства сменяются резкой духотой и прохладой. Вы просыпаетесь в хабе");
                Console.ReadLine();
                inhub = true;
                hub();
            }
            Death();
        }
        if (dopldodge > pldodgechance)
        {
            int dobbob = 0;
            if (doggystat[2] == 1)
            {
                Random rnd9 = new();
                dobbob = rnd9.Next(101);
            }
            if (dobbob <= 50)
            {
                double plus = 0;
                for (int aa = 0; (aa * 10 + 9)  < playerstat[0]; aa++)
                {
                    if(shieldhp[aa] >= attValue / 5)
                    {
                        plus += Convert.ToDouble(attValue) / 5;
                        shieldhp[aa] -= attValue / 5;
                    }
                    else if (shieldhp[aa] > 0)
                    {
                        plus += shieldhp[aa];
                        shieldhp[aa] = 0;
                    }
                }
                if (abilunlocks[0][5])
                {
                    hp += Convert.ToInt32(plus / 10);
                    Console.WriteLine("Ваша защита восстанавливает вам " + Convert.ToInt32(plus / 10) + " хп");
                }
                def += Convert.ToInt32(plus);
                parry += Convert.ToInt32(plus);
                minushp -= def;
                if (minushp <= 0)
                    minushp = 0;
                if (oshparry)
                    Console.WriteLine("Вы парировали удар!");
                oshparry = false;
                if (parry > 0)
                {
                    if (playerstat[0] >= currentloc * 10 - 10 && parry <= enemymaxhp / 5)
                        parry += enemymaxhp / 10;
                    if (abilunlocks[0][3])
                        parry += parry / 3;
                    Random rnd101 = new();
                    pcrit = rnd101.Next(101);
                    if (abilunlocks[0][2] && pcrit <= 10 + (playerstat[0] / 4))
                        Console.WriteLine("Критическое парирование!");
                    Console.WriteLine("Вы отразили " + parry + " урона");
                    enemyhp -= parry;
                }
                Random rnd10 = new();
                int docrit = rnd10.Next(101);
                if (docrit <= 15 && artefact[0])
                {
                    Console.WriteLine("Критический урон!");
                    minushp = (minushp * 15 / 10);
                }
                else if (docrit <= 5)
                {
                    Console.WriteLine("Критический урон!");
                    minushp = (minushp * 15 / 10);
                }
                Console.WriteLine(enemyname + " наносит вам урон в " + (minushp) + " ХП");
                if (hubreacts[10])
                {
                    Console.WriteLine(enemyname + " наносит вам урон в " + (minushp) + " ХП");
                    minushp *= 2;
                }
                if (magicduration[8] <= 0)
                    hp -= minushp;
            }   else
            {
                Console.WriteLine(enemyname + " наносит урон вашей гончей в " + (minushp) + " ХП");
                doggystat[0] -= minushp;
            }
        }
        Console.ReadLine();
        if (fightwith[0])
        {
            string[] bible = { "И сказал он: сотворим ящеров по образу Нашему и по подобию Нашему, и да владычествуют они над рыбами морскими, и над птицами небесными, и над скотом, и над всею землею, и над всеми гадами, пресмыкающимися по земле.", "Так говорит Ведущий, Святой Хельгии и Создатель её: вы спрашиваете Меня о будущем детей Моих и хотите Мне указывать в деле рук Моих?", "Ибо пути его неисповедимы, и весь \"беспредел\" творимый им абсолютно оправдан", "Ты понимаешь о ком я говорю? Ты понимаешь? Я сотворитель всего сущего, а ты - предатель всего творения", "Лизарды сказали Ему в ответ: не за доброе дело хотим побить Тебя камнями, но за богохульство и за то, что Ты, будучи грешник, делаешь Себя Богом." };
            if (wordnumber < bible.Length)
            {
                Console.Clear();
                Console.WriteLine("Нечто: " + bible[wordnumber]);
                Console.ReadLine();
                wordnumber++;
            }
        }
        if (fightwith[1])
        {
            string[] mywords = { "САТАНА!","МОГИЛА!","КЛАДБИЩЕ!","РОК!","РОК!","КИШКИ!","КРЕСТЫ!","КРОВЬ!","КЛАДБИЩЕ!","САТАНА!","ЧЕРТИ!"};
            if (wordnumber < mywords.Length)
            {
                Console.Clear();
                Console.WriteLine("Гуль Рокер: " + mywords[wordnumber]);
                Console.ReadLine();
                wordnumber++;
                if (wordnumber >= mywords.Length)
                wordnumber = 0;
            }
        }
        playerstep = 0;
        if (artefact[1])
        {
            def -= attValue;
            if (def < 0) { def = 0; }
        }
        if (!artefact[1])
            def = 0;
        if (magicduration[4] > 0)
            magicduration[4]--;
    }
    if (hp <= 0)
    {
        hubreacts[5] = false;
        hubreacts[9] = false;
        hubreacts[10] = false;
        Console.Clear();
        wordnumber = 0;
        itisnothe();
        if (!hubreacts[1])
        {
            Console.WriteLine("Вы пали от рук великого и ужасного " + enemyname + ". Нажмите Enter, чтобы начать игру сначала, либо закройте игру.");
            Console.ReadLine();
            gamestart();
        }
        else
        {
            if (!hubreacts[2])
            {
                Console.WriteLine("Вы умерли. Но вы всё ещё способны чувствовать");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Вы вспоминаете свежий воздух полей, палящее солнце пляжа...");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Однако все эти чувства сменяются резкой духотой и прохладой. Вы просыпаетесь в хабе");
                Console.ReadLine();
                hub();
            }
        }
    }
    void itisnothe()
    {
        for (int aa = 0; aa < fightwith.Length; aa++)
            fightwith[aa] = false;
    }
    Death();
    void Death()
    {
        if (enemyhp <= 0)
        {
            int[] watchtheloot = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            hubreacts[9] = false;
            hubreacts[10] = false;
            if (artefact[3])
                gainxp = 0;
            playerxp += gainxp;
            xpgains[xpgains[5][0]][xpgains[5][1]] -= gainxp * 15 / 100;
            for (int aa = 0; aa < dropchance.Length; aa++)
            {
                Random doloot = new Random();
                int foof = doloot.Next(0, 101);
                if (artefact[3])
                    dropchance[aa] /= 2;
                if (foof < dropchance[aa])
                {
                    droppest[aa] = true;
                    bool doplusdropp = true;
                    doyoufinditem[aa] = true;
                    while (doplusdropp)
                    {
                        craftitems[aa]++;
                        Random doplus = new Random();
                        int fooof = doplus.Next(101);
                        doplusdropp = false;
                        int bb = 20;
                        if (artefact[3])
                            bb = 60;
                        if (fooof < bb)
                        {
                            watchtheloot[aa]++;
                            doplusdropp = true;
                        }
                    }
                }
            }
            Console.Clear();
            bool theshowingdrop = false;
            for (int aa = 0; aa < droppest.Length; aa++)
            {
                if (droppest[aa])
                    theshowingdrop = true;
            }
            Console.WriteLine(enemyname + " повержен");
            Console.WriteLine("Вы получили " + gainxp + " очков опыта");
            if (theshowingdrop)
            {
                Console.Write("Покопавшись в останках, вы нашли: ");
                int ishowthisyea = 0;
                for (int aa = 0; aa < droppest.Length; aa++)
                {
                    if (xpgains[xpgains[5][0]][xpgains[5][1]] == 1234 && aa < 1)
                    {
                        Console.Write("Артефакт Героя");
                        findartefact[5] = true;
                    }
                    if (droppest[aa])
                    {
                        Console.Write(droppesttext[aa]);
                        ishowthisyea++;
                    }
                    if (watchtheloot[aa] > 0)
                        Console.Write("(" + (watchtheloot[aa] + 1) + ")");
                    if ((aa + 2) <= droppest.Length && ishowthisyea > 0)
                    {
                        if (droppest[aa + 1])
                            Console.Write(", ");
                    }
                }
            }
            Console.ReadLine();
            killtoreturn++;
            killtocamp++;
            while (playerxp >= 100)
            {
                chlevel++;
                playerxp -= 100;
                upgradepoints ++;
                Console.Clear();
                Console.WriteLine("Поздравляем! Уровень вашего персонажа повышен. Ваш нынешний уровень " + chlevel);
                Console.ReadLine();
            }
            theshowingdrop = false;
            for (int aa = 0; aa < droppest.Length; aa++)
            {
                droppest[aa] = false;
                watchtheloot[aa] = 0;
                dropchance[aa] = 0;
            }
            magicduration[0] = 0;
            if (gainxp == 1234)
            {
                Console.Clear();
                dialogopt[0][13] = true;
                string[] fixx = { "Нечто, в очередной раз ударившись об ваши щитки, замирает. \"Мешок\" с его телом рвётся и внутренности падает на пол", "Вы со всей силы разрубаете Нечто на две части. Останки, похожие на человечьи вываливаются из остатков мешка", "Нечто получил свой последний удар заклинанием. \"Мешок\" с его телом разрывается и всё, что внутри падает на пол" };
                    Console.WriteLine(fixx[maxstat]);
                    Console.ReadLine();
                string[] wowmassive = {"Вы вглядываетесь в останки Нечто", "Это был...", "Это был... Человеческий.", "Это был... Человеческий ребёнок.", "Это был... Человеческий ребёнок..", "Это был... Человеческий ребёнок..",  "Вокруг вас всё темнеет", "Вы упали и ударились головой о трубу. Вы теряете сознание", "Вы просыпаетесь на знакомой койке хаба. Хэнк, сидя за столом исписывает какие-то бумаги" ,"Но вас не посещают никакие мысли, ведь это долгожданный момент спокойствия.", "Хэнк: О, ты наконец проснулся. Честно признаться, я охренел с твоих результатов" , "Хэнк: Один ты уничтожил целую противоборствующую армию, с чем не могли справиться... Ну, пара неопытных добровольцев", "Хэнк: Всё-равно это не отменяет твои великие заслуги. С твоим выходом экономика поползёт вверх, и всё благодаря тебе. Мы все тебе безмерно благодарны" , "Хэнк: Теперь ты не увидишь Мехализардов в других измерениях. Не жалей их, они давно потеряли своё прежнее обличие. Они машины, управляемые тем, что ты убил"
            ,"Хэнк: Что ж, можешь приниматься за работу. Отдохни, если надобно. Нам ещё многое предстоит сделать","","","","Да, привет. Спасибо, что поиграл в мою игру. Это мой первый тестовый проект, и я рад, что он удостоился твоего внимания","Если нетрудно, расскажи об игре друзьям, если они есть. Если же нет, надеюсь, ты их когда-нибудь найдёшь. Все достойны друзей","А я прощаюсь. Можешь дальше играть в игру, хоть по факту ты её уже закончил. Хорошего настроения :)"};
                for (int aa = 0; aa < 5; aa++)
                {
                    Console.Clear();
                    Console.WriteLine(wowmassive[aa]);
                    Console.ReadLine();
                }
                for (int aa = 0; aa < 1000; aa++)
                    Console.Write(")(:*(!8)*()*()?(_№%");
                for (int aa = 6; aa < wowmassive.Length; aa++)
                {
                    Console.Clear();
                    Console.WriteLine(wowmassive[aa]);
                    Console.ReadLine();
                }
                itisnothe();
                hub();
            }
            if (!hubreacts[4] && currentloc == 5)
            {
                Random rand = new();
                int dos = rand.Next(100);
                if (dos <= 3)
                {
                    string[] write = {"Когда бездыханный труп врага плюхнулся на землю, вы услышали звонкий звук будто падающего стекла", "Присмотревшись, вы замечаете рядом с трупом странный жемчужно-подобный шарик", "Вы не понимаете, зачем он и какова его цена, но всё-равно решаетесь взять", "Вы разблокировали портал в ????"};
                    for(int aaaa = 0; aaaa < write.Length; aaaa++)
                    {
                        Console.Clear();
                        Console.WriteLine(write[aaaa]);
                        Console.ReadLine();
                    }
                    dialogopt[0][12] = true;
                    hubreacts[4] = true;
                }
            }
            itisnothe();
            outofbattle();
        }
    }
    if(doggystat[0] <= 0 && doggystat[2] == 1)
    {
        doggystat[2] = 0;
        Console.WriteLine("Гончая исчезла в небытие");
        Console.ReadLine();
    }
    if (doyouslowhis && magicduration[4] <= 0)
    {
        attackdelay = Convert.ToByte(slowingarray[1]);
        doyouslowhis = false;
    }
    for (int aa = 0; aa < doublespells.Length; aa++)
    {
        if (magicduration[aa] <= 0)
            doublespells[aa] = false;
    }
        playermove();
}
void playermove()
{
    oshparry = false;
    string dropsword;
    if (stepsrem[0] > 0)
        dropsword = " [X]";
    else
        dropsword = "";
    int bb = playerstep;
    dodgenow = dodgechance - (playerstat[2] * 4 / 6);
    if (magicka > maxmagicka)
        magicka = maxmagicka;
    if (hp > maxhp)
        hp = maxhp;
    imadecrit = false;
    if (!ultrahit)
        plusdmg = 10 + playerstat[1] * 2;
    else
        plusdmg = 999999;
    if (!artefact[3] && currentloc == 5)
    {
        Console.Clear();
        Console.WriteLine("Вы испытываете сильный удар током. По ощущениям, вы будто провалились сквозь землю и продолжаете падать");
        Console.ReadLine();
        dialogopt[0][10] = true;
        inhub = false;
        hub();
    }
    Console.Clear();
    Console.Write("Что вы собираетесь делать?\n[z] Атака" + dropsword + "\n[x] Защита\n[c] Характеристика противника\n[v] Ваша характеристика\n[b] Ваш инвентарь\n");
    if (abilunlocks[0][1])
        Console.WriteLine("[a] Меню щитков");
    if (abilunlocks[2][0])
    {
        Console.WriteLine("[d] Концентрация");
        if (abilunlocks[2][1])
            Console.WriteLine("[f] Применение магии");
    }
    string playeraction = Console.ReadLine();
    if (playeraction == "z" || playeraction == "Z")
    {
        bool imadecrit = false;
        bool dopcrit = false;
        int docrit = 0;
        int dododge = 0;
        int attValue = 0;
        int attNow = 0;
        if (!abilunlocks[1][1])
        {
            Random rnd = new Random();
            if (abilunlocks[1][0])
            {
                docrit = rnd.Next(0, 100);
                if (docrit <= 5 + playerstat[0] / 2 && magicduration[7] <= 0 || docrit <= 15 + playerstat[0] + playerstat[0] / 2 && magicduration[7] > 0)
                    imadecrit = true;
            }
            bool tellaboutdmg = true;
            Console.Clear();
            Random rnd2 = new();
            attValue = rnd2.Next(plusdmg, (int)(plusdmg * 1.7));
            attNow = attValue - enemydef;
            if (attNow < 0)
                attNow = 0;
            if (imadecrit)
                attNow = (int)((Convert.ToDouble(attValue * 2) * (1 + Convert.ToDouble(playerstat[1] / 100))));
            Random rnd3 = new();
            dododge = rnd3.Next(0, 100);
            if (dododge <= dodgechance && !ultrahit)
            {
                attNow = 0;
                tellaboutdmg = false;
                Console.WriteLine("Вы промахнулись");
            }
            if (imadecrit && dododge > dodgechance)
            {
                Console.WriteLine("Критический удар!");
            }
            enemyhp -= attNow;
            if (tellaboutdmg)
                Console.WriteLine("Вы нанесли " + attNow + " урона");
            Console.ReadLine();
            playerstep++;
            if (artefact[5] && maxstat == 1)
                hp += attValue / 10;
            enemystep();
        }
        attack();
        void attack()
        {
            Console.Clear();
            if (stepsrem[0] > 0)
            {
                Console.WriteLine("Вы не можете атаковать, пока не вернёте меч");
                Console.ReadLine();
                enemystep();
            }
            Console.WriteLine("Способы атаки: \n[1] Обычный удар");
            if (abilunlocks[1][1])
            {
                Console.WriteLine("[2] Бросок меча");
                if (abilunlocks[1][3])
                    Console.WriteLine("[3] Кровавый удар");
                if (abilunlocks[1][4])
                    Console.WriteLine("[4] Резкий взмах");
            }
            Console.WriteLine("[e] выход");
            playeraction = Console.ReadLine();
            bool isNum = int.TryParse(playeraction, out int choice);
            void critregen(int attNow)
            {
                if (abilunlocks[1][5] && imadecrit || dopcrit && abilunlocks[1][5])
                    hp += attNow / 10;
            }
            Console.Clear();
            void handcrit()
            {
                if (abilunlocks[1][3])
                {
                    Random rnd3 = new();
                    int Neednumb = rnd3.Next(1, 6);
                    Console.Clear();
                    Console.WriteLine("Выберите число от 1 до 5: ");
                    playeraction = Convert.ToString(Console.ReadLine());
                    bool isNum = int.TryParse(playeraction, out int choice);
                    Console.Clear();
                    if (isNum && choice > 0 && choice < 6)
                    {
                        if (choice == Neednumb)
                        {
                            dopcrit = true;
                            attValue = (int)((Convert.ToDouble(attValue * 2) * (1 + Convert.ToDouble(playerstat[1] / 100))));
                            if (imadecrit && dododge > dodgechance)
                                Console.WriteLine("Суперкритический удар!");
                            else if (dododge > dodgechance)
                                Console.WriteLine("Критический удар!");
                            attNow = attValue;
                        }
                        else
                            Console.WriteLine("Ручной крит не сработал");
                    }
                    else
                        handcrit();
                }
            }
            if (!isNum)
                playermove();
            else if (choice == 1)
            {
                if (abilunlocks[1][0])
                {
                    Random rnd = new Random();
                    int docrit = rnd.Next(0, 100);
                    if (docrit <= 5 + playerstat[0] / 2 && magicduration[7] <= 0 || docrit <= 15 + playerstat[0] + playerstat[0] / 2 && magicduration[7] > 0)
                        imadecrit = true;
                }
                bool tellaboutdmg = true;
                Random rnd2 = new();
                attValue = rnd2.Next(10 + plusdmg, (int)((10 + plusdmg) * 1.7));
                attNow = attValue - enemydef;
                if (attNow < 0)
                    attNow = 0;
                Random rnd3 = new();
                dododge = rnd3.Next(0, 100);
                handcrit();
                if (dododge <= dodgechance && !ultrahit)
                {
                    attNow = 0;
                    tellaboutdmg = false;
                    Console.WriteLine("Вы промахнулись");
                }
                if (imadecrit && dododge > dodgechance && !ultrahit)
                {
                    Console.WriteLine("Критический удар!");
                    attNow = Convert.ToInt16((Convert.ToDouble(attValue * 2) * (1 + Convert.ToDouble(playerstat[1] / 100))));
                }
                if (magicduration[8] > 0)
                    attNow += attNow / 2 + enemydef / 2;
                enemyhp -= attNow;
                if (tellaboutdmg)
                    Console.WriteLine("Вы нанесли " + attNow + " урона");
                Console.ReadLine();
                playerstep++;
            }
            else if (choice == 2 && abilunlocks[1][1])
            {
                if (!iknowaboutthat[1])
                {
                    Console.Clear();
                    Console.WriteLine("Бросок меча лишает вас возможности атаковать в течении двух следующих атак противника, зато наносит в 1.75 раза больше урона");
                    Console.ReadLine();
                    iknowaboutthat[1] = true;
                }
                stepsrem[0] = 2;
                if (abilunlocks[1][0])
                {
                    Random rnd = new Random();
                    int docrit = rnd.Next(0, 100);
                    if (docrit <= 5 + playerstat[0] / 2 && magicduration[7] <= 0 || docrit <= 15 + playerstat[0] + playerstat[0] / 2 && magicduration[7] > 0)
                        imadecrit = true;
                }
                bool tellaboutdmg = true;
                Console.Clear();
                Random rnd2 = new();
                attValue = rnd2.Next(10 + plusdmg, (int)((10 + plusdmg) * 1.7));
                attNow = attValue - enemydef;
                if (attNow < 0)
                    attNow = 0;
                attNow += attNow / 2 + attNow / 4;
                Random rnd3 = new();
                dododge = rnd3.Next(0, 100);
                handcrit();
                if (dododge <= dodgechance && !ultrahit)
                {
                    attNow = 0;
                    tellaboutdmg = false;
                    Console.WriteLine("Вы промахнулись");
                }
                if (imadecrit && dododge > dodgechance && !dopcrit)
                {
                    Console.WriteLine("Критический удар!");
                    attNow = (int)((Convert.ToDouble(attValue * 2) * (1 + Convert.ToDouble(playerstat[1] / 100))));
                }
                if (magicduration[8] > 0)
                    attNow += attNow / 2 + enemydef / 2;
                enemyhp -= attNow;
                if (tellaboutdmg)
                    Console.WriteLine("Вы нанесли " + attNow + " урона");
                Console.ReadLine();
                playerstep++;
            }
            else if (choice == 3 && abilunlocks[1][3])
            {
                int hpned = maxhp / 10;
                if (!iknowaboutthat[2])
                {
                    Console.Clear();
                    Console.WriteLine("Кровавый удар забирает у вас 10% здоровья, следующая атака противника нанесёт лишь половину урона. Во время неё он также получит четверть урона вашей нынешней атаки, игнорируя свою защиту");
                    Console.ReadLine();
                    iknowaboutthat[2] = true;
                }
                if (hp > hpned || magicduration[8] > 0)
                {
                    if (magicduration[8] <= 0)
                        hp -= hpned;
                    Random rnd = new Random();
                    int docrit = rnd.Next(0, 100);
                    if (docrit <= 5 + playerstat[0] / 2 && magicduration[7] <= 0 || docrit <= 15 + playerstat[0] + playerstat[0] / 2 && magicduration[7] > 0)
                        imadecrit = true;
                    bool tellaboutdmg = true;
                    Console.Clear();
                    Random rnd2 = new();
                    attValue = rnd2.Next(10 + plusdmg, (int)((10 + plusdmg) * 1.7));
                    attNow = attValue - enemydef;
                    if (attNow < 0)
                        attNow = 0;
                    attpast = attValue / 4;
                    Random rnd3 = new();
                    dododge = rnd3.Next(0, 100);
                    handcrit();
                    if (dododge <= dodgechance && !dopcrit)
                    {
                        attNow = 0;
                        tellaboutdmg = false;
                        Console.WriteLine("Вы промахнулись");
                    }
                    if (imadecrit && dododge > dodgechance && !ultrahit)
                    {
                        Console.WriteLine("Критический удар!");
                        attNow = (int)((Convert.ToDouble(attValue * 2) * (1 + Convert.ToDouble(playerstat[1] / 100))));
                    }
                    if (magicduration[8] > 0)
                        attNow += attNow / 2 + enemydef / 2;
                    enemyhp -= attNow;
                    if (tellaboutdmg)
                        Console.WriteLine("Вы нанесли " + attNow + " урона");
                    Console.ReadLine();
                    playerstep++;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Вы не можете атаковать таким образом, вы при смерти.");
                    Console.ReadLine();
                    playermove();
                }
            }
            else if (choice == 4 && abilunlocks[1][4])
            {
                if (!iknowaboutthat[3])
                {
                    Console.Clear();
                    Console.WriteLine("Резкая атака удваивает ваш максимальный возможный урон, но и опускает минимальный до нуля");
                    Console.ReadLine();
                    iknowaboutthat[3] = true;
                }
                if (abilunlocks[1][0])
                {
                    Random rnd = new Random();
                    int docrit = rnd.Next(0, 100);
                    if (docrit <= 5 + playerstat[0] / 2 && magicduration[7] <= 0 || docrit <= 15 + playerstat[0] + playerstat[0] / 2 && magicduration[7] > 0)
                        imadecrit = true;
                }
                bool tellaboutdmg = true;
                Console.Clear();
                Random rnd2 = new();
                attValue = rnd2.Next(1, (int)((10 + plusdmg) * 3.4));
                attNow = attValue - enemydef;
                if (attNow < 0)
                    attNow = 0;
                if (imadecrit)
                    attNow = (int)((Convert.ToDouble(attValue * 2) * (1 + Convert.ToDouble(playerstat[1] / 100))));
                Random rnd3 = new();
                dododge = rnd3.Next(0, 100);
                handcrit();
                if (dododge <= dodgechance && !dopcrit)
                {
                    attNow = 0;
                    tellaboutdmg = false;
                    Console.WriteLine("Вы промахнулись");
                }
                if (imadecrit && dododge > dodgechance && !ultrahit)
                    Console.WriteLine("Критический удар!");
                if (magicduration[8] > 0)
                    attNow += attNow / 2 + enemydef / 2;
                enemyhp -= attNow;
                if (tellaboutdmg)
                    Console.WriteLine("Вы нанесли " + attNow + " урона");
                Console.ReadLine();
                playerstep++;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Неизвестный вариант. Попробуйте выбрать из доступных видов атаки");
                Console.ReadLine();
                attack();
            }
            if (abilunlocks[1][5] && imadecrit || abilunlocks[1][5] && dopcrit)
                hp += attNow / 10;
            if (artefact[5] && maxstat == 1)
                hp += attNow / 10;
            if (magicduration[7] > 0)
                magicduration[7]--;
        }
    }
    else if (playeraction == "x" || playeraction == "X")
    {
        Console.Clear();
        Random defplus = new();
        int defValue = defplus.Next(5 + playerstat[0], playerstat[0] + 5 + playerstat[0] / 4);
        playerstep++;
        if (artefact[1])
            defValue = defValue * 3 / 5;
        def += defValue;
        Console.WriteLine("Ваша защита в этом ходу повышена на " + defValue + " очков");
        Console.ReadLine();
        Random rnd = new();
        int dopar = rnd.Next(0, 100);
        if (abilunlocks[0][0] && dopar <= 25 + playerstat[0])
            oshparry = true;
    }
    else if (playeraction == "c" || playeraction == "C")
    {
        string stepword = "";
        if (attackdelay == 1)
            stepword = "ход";
        else if (attackdelay == 2 || attackdelay == 3 || attackdelay == 4)
            stepword = "хода";
        else
            stepword = "ходов";
        string bobb;
        if (doyouslowhis)
            bobb = Convert.ToString("(" + slowingarray[1] + ")");
        else
            bobb = "";
        Console.Clear();
        Console.WriteLine("Сущность: " + enemyname + "\nОсталось здоровья: " + enemyhp + "/" + enemymaxhp + "\nСредняя сила атаки: " + (enemystrMAX - (enemystrMAX / 4)) + "\nЗащита по умолчанию: " + enemydef + "\nШанс уклонения: " + dodgechance + "%\nЗадержка атак: " + attackdelay + bobb + " " + stepword + "\n" + description);
        Console.ReadLine();
        playerstep++;
    }
    else if (playeraction == "v" || playeraction == "V")
    {
        Console.Clear();
        Console.WriteLine("Уровень персонажа: " + chlevel + "\nВаш опыт: " + playerxp + "/100\nВаше здоровье: " + hp + "/" + maxhp + "\nВаш средний урон: " + (int)((plusdmg) * (1.35)));
        if (artefact[1])
            Console.WriteLine("Ваша защита составляет " + def + " единиц. (Артефакт накопления защиты)");
        if (abilunlocks[2][1])
            Console.WriteLine("Ваша мана: " + magicka + "/" + maxmagicka);
        if (doggystat[2] == 1)
            Console.WriteLine("\nЗдоровье гончей: " + doggystat[0] + "\nСредняя сила атаки гончей: " + doggystat[1]);
        Console.ReadLine();
    }
    else if (playeraction == "b" || playeraction == "B")
        playerinventory();
    else if (abilunlocks[0][1] && playeraction == "a" || abilunlocks[0][1] && playeraction == "A")
    {
        shields();
        void shields()
        {
            Console.Clear();
            Console.WriteLine("Состояние щитков:");
            for (int aa = 0; aa < shieldhp.Length; aa++)
            {
                if (shieldhp[aa] <= 0)
                    shieldhp[aa] = 0;
                string brok = "";
                if (shieldhp[aa] <= 0)
                    brok = " (сломан)";
                if ((aa + 1) * 10 <= playerstat[0])
                    Console.WriteLine("[" + (aa + 1) + "] " + shieldhp[aa] + "/" + (playerstat[0] * 2) + " хп" + brok);
            }
            Console.WriteLine("[e] Выход");
            playeraction = Console.ReadLine();
            bool isNum = int.TryParse(playeraction, out int choice);
            if (isNum && (choice * 10) <= playerstat[0] && choice > 0)
            {
                if (!iknowaboutthat[5])
                {
                    Console.Clear();
                    Console.WriteLine("Выбирая номер щитка, вы выделяете ход на ремонт этого щитка");
                    Console.ReadLine();
                    Console.Clear();
                    if (!abilunlocks[0][4])
                    Console.WriteLine("1/10 восстановленной прочности щитка восстановит остальные имеющийся щитки");
                    else
                        Console.WriteLine("1/5 восстановленной прочности щитка восстановит остальные имеющийся щитки");
                    Console.ReadLine();
                    iknowaboutthat[5] = true;
                }
                int hil = playerstat[0] * 3 / 4;
                if (magicduration[9] > 0)
                    hil += hil + hil / 2;
                for (int aa = 0; (aa * 10 + 9) < playerstat[0]; aa++)
                {
                    if (aa != choice - 1)
                    {
                        shieldhp[aa] += hil / 10;
                        if (abilunlocks[0][4])
                            shieldhp[aa] += hil / 10;
                    }
                    else
                        shieldhp[aa] += hil;
                    if (shieldhp[aa] > (playerstat[0] * 2))
                        shieldhp[aa] = playerstat[0] * 2;
                }
                playerstep++;
                enemystep();
            }
            else if (!isNum)
            {
                playermove();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Такого щитка не существует");
                Console.ReadLine();
                shields();
            }
        }
    }
    else if (abilunlocks[2][0] && playeraction == "d" || abilunlocks[2][0] && playeraction == "D")
    {
        if (!iknowaboutthat[0])
        {
            Console.Clear();
            Console.WriteLine("Концентрация влияет напрямую на ваш уровень интелекта, однако она сбрасывается сразу после атаки противника. Использование её несколько раз подряд сильнее увеличивает получаемые параметры\nС каждым использованием концентрации подряд растёт шанс макроразрыва. При макроразрыве ваша концентрация будет сбита, вам будет нанесён урон, равный увеличенному количеству параметров разума, а ходы будут пропущены до момента атаки противника.");
            Console.ReadLine();
            iknowaboutthat[0] = true;
        }
        if (magicduration[8] <= 0)
        {
            Random doanti = new();
            int anti = doanti.Next(0, 100);
            if (artefact[5] && maxstat == 2)
                anti /= 2;
            if (anti <= concentratioon[1] * 10 * concentratioon[1] - playerstat[2] * 2)
            concentration = true;
            concentratioon[1]++;
            concentratioon[0] = (10 + playerstat[2] / 5) * (1 + concentratioon[1] / 5);
            playerstat[2] += concentratioon[0];
            concentratioon[2] += concentratioon[0];
            void mental()
            {
                Console.Clear();
                Console.WriteLine("Вы впадаете в замешательство. Вы падаете от сильной боли в голове, произошло перенапряжение\nВы получили " + concentratioon[0] + " урона");
                Console.ReadLine();
                hp -= concentratioon[0];
                playerstep = attackdelay;
            }
        }
        playerstep++;
        string[] concdialogue = { "Вы всматриваетесь в лицо противника. Похоже, не только вы недовольны битвой, но отступать он не собирается. Вы готовы к любому продолжению событий", "Вы крепко сжимаете кулаки. Ничего не меняется, но самовнушение работает на все 100. Ваш боевой дух поднят", "Вы ощущаете бесконечность этого места. Ваша решимость столь же бесконечна. Ваши мыслительные способности усилены", "Вы понимаете, что боль это дар. Все ваши заслуги ничего бы не стоили, если бы не боль. Ваша мотивация усилена", "Вы чувствуете, как энергия бушует в вашем теле. В вас сокрыт скрытый потенциал, это заставляет вас не сдаваться. Ваше восприятие усилено" };
        Random concdialog = new();
        int concdialogg = concdialog.Next(0, 5);
        Console.Clear();
        if (magicduration[8] <= 0)
            Console.WriteLine(concdialogue[concdialogg]);
        else
            Console.WriteLine("Технология не даёт вам сконцентрироваться");
        Console.ReadLine();
    }
    else if (abilunlocks[2][1] && playeraction == "f" || abilunlocks[2][1] && playeraction == "F")
    {
        magicuse();
        void magicuse()
        {
            int playerstat2 = 5 + playerstat[2] / 2;
            if (artefact[1])
                playerstat2 = playerstat2 * 3 / 5;
            string[] spellnames = { "Шар микро-распада", "Регенерация", "Колючий щит", "Призрачная гончая", "Заморозка", "Суперпозиция" };
            string[] spelleffects = { "Бросается в противника, разрушает его изнутри. Наносит " + (5 + playerstat[2] / 2) + " урона в течении 3 ходов", "Восстанавливает здоровье на " + (5 + playerstat[2] / 2) + " очков в течении 3 ходов", "Даёт вам " + (playerstat[2]) + " защиты. Врагу отразится весь поглощёный урон", "Создаёт неконтролируемую гончую, которая атакует противника и отвлекает внимание на себя", "Окружает врага потоком ледяных осколков, заставляющих его атаковать на ход позднее. Длится в течении 4 атак противника", "Перемещает ваше тело в абсолютное положение этого измерения. Гарантированное уклонение от следующей атаки противника" };
            int[] spellcost = { 25 + playerstat[2] / 3, 25 + playerstat[2] / 3, 30 + playerstat[2] / 3, 80, 120, 100 };
            int inthisnubmerstop = 0;
            Console.Clear();
            Console.WriteLine("Осталось маны: " + magicka + "/" + maxmagicka + "\nВаши заклинания:");
            for (int aa = 0; aa < spelleffects.Length; aa++)
                if (foundspell[aa])
                {
                    Console.WriteLine("[" + (aa + 1) + "] " + spellnames[aa]);
                    inthisnubmerstop = aa + 1;
                }
            Console.WriteLine("[e] Выход");
            playeraction = Console.ReadLine();
            bool isNum = int.TryParse(playeraction, out int choice);
            if (isNum)
            {
                if (choice > 0 && choice < (spelleffects.Length + 1) && choice <= inthisnubmerstop)
                {
                    int ch1 = choice - 1;
                    Console.Clear();
                    Console.WriteLine(spellnames[ch1] + ": " + spelleffects[ch1] + "\nСтоимость: " + spellcost[ch1] + " маны\n        y - Применить   n - Не применять");
                    string playeraction = Console.ReadLine();
                    if (playeraction == "y" || playeraction == "Y")
                    {
                        Console.Clear();
                        bool dodouble = false;
                        if (magicka < spellcost[ch1])
                        {
                            Console.WriteLine("Не хватает маны");
                            Console.ReadLine();
                            playermove();
                        }
                        if (artefact[2])
                        {
                            Random rnd111 = new();
                            byte domiss = Convert.ToByte(rnd111.Next(100));
                            if (domiss < 33)
                            {
                                Console.WriteLine("Заклинание не удалось");
                                if (magicduration[8] <= 0)
                                    magicka -= spellcost[ch1];
                                playerstep++;
                                Console.ReadLine();
                                enemystep();
                            }
                            else if (domiss < 66)
                            {
                                Console.WriteLine("Эффект заклинания удвоен!");
                                doublespells[ch1] = true;
                                dodouble = true;
                            }
                        }
                        int[] newduration = { 3, 3, 1, 1, 4, 1 };
                        magiceffects[ch1] = true;
                        if (magicduration[8] <= 0)
                            magicka -= spellcost[ch1];
                        magicduration[ch1] = newduration[ch1];
                        if (ch1 == 0)
                        {
                            for (int aa = 0; aa < ballsteps.Length; aa++)
                            {
                                if (ballsteps[aa] <= 0)
                                {
                                    ballsteps[aa] = 3;
                                    if (dodouble && aa < ballsteps.Length)
                                    {
                                        doublespells[0] = false;
                                        ballsteps[aa + 1] = 3;
                                    }
                                    break;
                                }
                            }
                        }
                        if (dodouble = false)
                            doublespells[ch1] = false;
                        Console.WriteLine("Заклинание \"" + spellnames[ch1] + "\" использовано");
                        Console.ReadLine();
                        playerstep++;
                    }
                    else
                    {
                        magicuse();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Такого заклинания не существует");
                    Console.ReadLine();
                    magicuse();
                }
            }
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Неизвестное действие. Нажмите ENTER и продолжите игру");
        Console.ReadLine();
    }
    if (hp > maxhp)
        hp = maxhp;
    if (bb < playerstep)
    {
        if (artefact[5] && maxstat == 0)
            for (int aa = 0; (aa * 10 + 9) < playerstat[0]; aa++)
                shieldhp[aa] += playerstat[0] / 15;
        int mreg = maxmagicka / 20 + magicka / 5 + 5;
        while (mreg > 30)
            mreg -= mreg / 10;
        magicka += mreg;
        Console.Clear();
        if (artefact[0])
            hp += maxhp / 20;
        if (abilunlocks[0][3])
            hp += maxhp / 40;
        magicduration[8]--;
        bool doball = false;
        if (magicduration[10] > 0)
        {
            int dmg = chlevel / 3 + 5;
            for (int aa = 4; aa != magicduration[10]; aa--)
                dmg *= 2;
            enemyhp -= dmg;
            Console.WriteLine("Ядовитый газ наносит противнику " + dmg + " урона");
            magicduration[10]--;
        }
        for (int aa = 0; aa < ballsteps.Length; aa++)
        {
            int balldamage = 5 + playerstat[2];
            if (doublespells[0])
                balldamage *= 2;
            if (playerstat[2] >= currentloc * 10 - 10 && balldamage < enemymaxhp / 15)
                balldamage += enemymaxhp / 20;
            if (ballsteps[aa] > 0)
            {
                doball = true;
                enemyhp -= balldamage;
                Console.WriteLine("Шар микро-распада наносит противнику " + balldamage + " урона");
                if (doublespells[0])
                    enemyhp -= balldamage;
                ballsteps[aa]--;
            }
        }
        if (doball || magicduration[10] > 0)
            Console.ReadLine();
        if (doggystat[2] == 1)
        {
            void dogatt()
            {
                Random rnd5 = new();
                int dodogge = rnd5.Next(0, 90);
                int doggybeat = 0;
                if (dodogge <= dodgechance && !ultrahit)
                    Console.WriteLine("Гончая промахнулась");
                else
                {
                    Random rnd4 = new();
                    int damage = rnd4.Next(1, (10 + playerstat[2]));
                    int damageminus = damage - (enemydef * 4 / 5);
                    if (damageminus < 0)
                        damageminus = 0;
                    Console.WriteLine("Гончая наносит противнику " + damageminus + " урона");
                    enemyhp -= damageminus;
                }
            }
            if (doublespells[2])
            {
                dogatt();
                dogatt();
            }
            else
            {
                dogatt();
            }
            Console.ReadLine();
        }
    }
    enemystep();
}
void gamestart()
{
    currentloc = 1;
    maxmagicka = 0;
    magicka = 0;
    maxhp = 50;
    hp = 50;
    chlevel = 1;
    money = 87;
    playerxp = 0;
    for (int aa = 0; aa < xpgains[0].Length; aa ++)
        xpgains[0][aa] = 50;

    if (!skipintro)
    {
        Console.WriteLine("Добро пожаловать в Just another RPG game. Нажмите Enter, чтобы продолжить.");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Вы проснулись посреди огромного поля. Солнышко светит, цветочки благоухают.");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("На вас только грязные лохмотья. У вас нет причин полагать, что так было не всегда, ведь вы потеряли память.");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Во всём этом спокойствии вы начинаете слышать хлюпающие звуки. Вы оборачиваетесь. Это-же слизень!");
        Console.ReadLine();
        Console.Clear();
    }
    SlimeFight();
}
void outofbattle()
{
    stepsrem[0] = 0;
    enemynmoglas = false;
    if (!slimereact)
    {
        Console.Clear();
        Console.WriteLine("Эта битва заставила вас понять небезопасность вашего положения");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("На этих бескрайних просторах вы не видите ни души");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Вы об этом думаете? Нет. Эти слова должное, эти мысли безконтрольны. Способны ли вы всё ещё мыслить?");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Думаю это не так важно. Вокруг вас километры пустоты, но вы не одиноки. Почему-же? А вот почему");
        Console.ReadLine();
        slimereact = true;
        TumbleweedFight();
    }
    if (killtocamp < 5 && killtoreturn < 20)
    {
        if (!inbattle)
        {
            string[] coolstories = { "Вы заглядываетесь на небо. Вы тонете в раздумьях, каково же не существовать", "Вы осматриваете себя. Вы понимаете, что пара ран на теле не затмит смысл существования", "Вы гуляете по бескрайнему полю. Вам кажутся одновременно забавными и тревожными мысли о выпадении из реальности", "Вы видите вдали движение. Вы ощущаете смыслом жизни подойти к чему-то и в очередной раз лишить что-то существования", "Ваша голова пуста. Ваш мыслительный сосуд слился с окружающим вас ветром. Так будет не всегда. Наслаждайтесь" };
            if (hubreacts[1])
            coolstories[2] = "Кажется, вы начинаете забывать. Не бойтесь, сойти с этого пути невозможно";
            Random rnd = new();
            int nbtell = rnd.Next(1, 5);
            Console.Clear();
            Console.WriteLine(coolstories[nbtell]);
            Console.ReadLine();
            Random rnd2 = new();
            nbcreature = rnd.Next(1, 201);
        }
        if (currentloc == 1)
        {
            inbattle = true; 
            if (nbcreature <= 46)
                SlimeFight();
            else if (nbcreature <= 92)
                TumbleweedFight();
            else if (nbcreature <= 138)
                RabbytkillerFight();
            else if (nbcreature <= 155)
                theTrollHearteaterFight();
            else if (nbcreature <= 200)
                UmbrellaSpider();
        }
        else if (currentloc == 2) 
        {
            dialogopt[0][4] = true;
            if (nbcreature <= 46)
                rockfisherFight();
            else if (nbcreature <= 92)
                MummyFight();
            else if (nbcreature <= 138)
                GoblinArmored();
            else if (nbcreature <= 155)
                armacrabFight();
            else if (nbcreature <= 200)
                MonsterTentacle();
        }
        else if (currentloc == 3) 
        {
            if (nbcreature <= 46)
                GhoulTheRockerFight();
            else if (nbcreature <= 92)
                CuteLittleGirlFight();
            else if (nbcreature <= 138)
                MechaLizardScoutFight();
            else if (nbcreature <= 155)
                NecROMANcerFight();
            else if (nbcreature <= 200)
                twoheadedbearFight();
        }
        else if (currentloc == 4)
        {
            if (nbcreature <= 40)
                MechaLizardDrillerFight();
            else if (nbcreature <= 80)
                MechaLizardMilitaryFight();
            else if (nbcreature <= 120)
                MechaLizardControllerFight();
            else if (nbcreature <= 160)
                StaticTurretFight();
            else if (nbcreature <= 200)
                TransportDroneFight();
        }
        else if (currentloc == 5)
        {
            if (!artefact[3])
            {
                Console.Clear();
                Console.WriteLine("Вы испытываете сильный удар током. По ощущениям, вы будто провалились сквозь землю и продолжаете падать");
                Console.ReadLine();
                inhub = false;
                dialogopt[0][10] = true;
                currentloc = 0;
                hub();
            }
            dialogopt[0][11] = true;
            if (nbcreature <= 40)
                MechaLizardCreatorFight();
            else if (nbcreature <= 80)
                LizardFight();
            else if (nbcreature <= 120)
                LizardPropagandistFight();
            else if (nbcreature <= 160)
                LizardMechanicFight();
            else if (nbcreature <= 200)
                LizardInformantFight();
        }
    }
    else if (killtocamp >= 5 && killtoreturn < 20)
    {
        camptell = false;
        timetocamp();
    }
    else if (killtoreturn == 20)
    {
        if (currentloc == 2)
        {
            dopotionfind[2] = true;
            dopotionfind[3] = true;
            dopotionfind[4] = true;
            dialogopt[0][4] = true;
        }
        if (currentloc == 2)
        {
            dopotionfind[5] = true;
            dopotionfind[6] = true;
        }
        if (currentloc == 4)
        {
            hubreacts[3] = true;
            dialogopt[0][7] = true;
        }
        killtocamp = 0;
        killtoreturn = 0;
        inhub = false;
        hub();
    }
    else if (killtoreturn > 20)
        ImError();
}
void timetocamp()
{
    if (!artefact[3] && currentloc == 5)
    {
        Console.Clear();
        Console.WriteLine("Вы испытываете сильный удар током. По ощущениям, вы будто провалились сквозь землю и продолжаете падать");
        Console.ReadLine();
        inhub = false;
        currentloc = 0;
        hub();
    }
    string newrang = "";
    if (upgradepoints > 0)
    {
        newrang = " (Доступны новые улучшения!)";
    }
    Console.Clear();
    if (!camptell)
    {
        for (int aa = 0; (aa * 10 + 9) < playerstat[0]; aa++)
        {
            shieldhp[aa] = playerstat[0] * 2;
        }
        Console.WriteLine("Вы очутились в разбитом лагере. Хоть вы и одни, тут весьма уютно");
        Console.ReadLine();
        camptell = true;
    }
    Console.Clear();
    Console.WriteLine("Ваши действия: \n[1] Отдых\n[2] Улучшение навыков" + newrang + "\n[3] Создание расходников\n[4] Инвентарь");
    if (inhub)
    {
        Console.WriteLine("[e] Вернуться");
    }
    string playeraction = Console.ReadLine();
    if (playeraction == "1")
    {
        Console.Clear();
        maxhp = Convert.ToInt32((45 + Convert.ToDouble(chlevel) * 5) * ((1 + Convert.ToDouble(playerstat[0]) / 50)));
        hp = maxhp;
        maxmagicka = playerstat[2] * 4;
        magicka = maxmagicka;
        pldodgechance = 10 + playerstat[2] / 2;
        if (inhub)
        {
            Console.Clear();
            Console.WriteLine("Только вы легли на кровать, вы сразу наполнились энергией. Магия, не правда ли? Жаль вам придётся меньше отлынивать от работы");
            Console.ReadLine();
            hub();
        }
        Console.WriteLine("Вы хорошо отдохнули. Ваше здоровье восстановлено до предела. Лагерь куда-то пропал, но вас это не должно беспокоить");
        Console.ReadLine();
        killtocamp = 0;
        camptell = false;
        outofbattle();
    }
    else if (playeraction == "2")
    {
        upgrademenu();
        void upgrademenu()
        {
            Console.Clear();
            Console.WriteLine("Свободные очки улучшений: " + upgradepoints + "\n[1] Живучесть- " + playerstat[0] + "\n[2] Сила- " + playerstat[1] + "\n[3] Разум- " + playerstat[2] + "\n[c] Информация о навыках\n[e] Выход");
            playeraction = Console.ReadLine();
            int choice;
            bool isNum = int.TryParse(playeraction, out choice);
            if (isNum)
            {
                if (choice > 0 && choice < 4)
                    auto();
                else
                {
                    Console.Clear();
                    Console.WriteLine("Выбранного вами навыка не существует");
                    Console.ReadLine();
                    upgrademenu();
                }
            }
            else if (playeraction == "c")
            {
                Console.Clear();
                Console.WriteLine("Живучесть - ваша способность выдерживать атаки противников, защищаться и парировать их\n\nСила- ваше умение наносить более сильные удары по противнику, а также увеличение шанса и урона критических атак\n\nРазум- основа восприятия, помогающая наносить более точные удары по противнику, колдовать, ловко уворачиваться от атак и пользоваться концентрацией");
                Console.ReadLine();
                upgrademenu();
            }
            else
            {
                hidethis();
                void hidethis()
                {
                    string[][][] messages =
    {
        new string[][]
        {
            new string[] {"Вы удобно разваливаетесь на земле. Вы вспоминаете своё несчастное детство", "Несмотря на весьма престижную работу сейчас, тогда вас никто не уважал и все об вас вытирали ноги", "Долгом каждого было посмеяться над вами, отпустить обидную шутку и как можно сильнее ударить", "Хоть это и давно прошло, жизнь вынуждает вас постоянно терпеть и по сей день", "Вам давно стоило научиться глобально постоять за себя", "Злость одолевает вас", "Вы разблокировали парирования!\n(Любое блокирование щитом теперь имеет шанс отразить часть урона противнику)"},
            new string[] {"Вы с усталостью вздыхаете. В последнее время вы стали уставать намного быстрее, хоть и объём работы всё тот же", "Может быть это депрессия? Или ваш организм стареет? Неважно","Вас интересует только решение проблемы. \"Лень - двигатель прогресса\", плотно обдумываете вы в голове", "Вас переполняет уверенность", "Вы разблокировали щитки!\n(1/5 любого урона будет поглощена щитком, если у него достаточно прочности. Вы можете чинить щитки, тратя ходы. 1 новый щиток появляется каждые 10 уровней. Весь поглощённый урон будет отражена противнику)"},
            new string[] {"Вы съедаете очередной большой кусок хлеба. Здесь вас никто не осудит за ваши плохие привычки, ведь вы одни", "В конце концов вы создаёте больше, чем потребляете. Или по крайней мере заимствуете", "Вам лень думать о чём либо, только эгоистичное желание стать сильнее", "Вы осматриваете свой щит и щитки", "Весь отражаемый урон увеличен!"},
            new string[] {"\"Ленивым везёт\" - вспоминается завистливая фраза одного из ваших старых друзей", "Вы так не думаете. На вас ответственная ноша, и единственное ваше везение - редкие комфортные условия", "Бои - штука случайная, вы должны это понимать, и вы это понимаете", "Один момент с лёгкостью может решить исход боя, и вы вполне способны с ним совладать, но с чем же?", "Тяжёлые мысли посещают вашу голову", "Вы разблокировали критические парирования!"},
            new string[] {"В вашей голове возникают мысли о возможных негативных последствиях вашей лени", "Чревоугодие это далеко не то, чему вас учили родители. Но одновременно с этим вас всё устраивает", "Единственное, что хочется сделать: избавиться от лишней работы", "Вы тренеруетесь в ремонте щитков", "Ремонт невыбранных щитков теперь в 2 раза эффективнее!"},
            new string[] {"Вы с трудом встаёте с земли. Набранные килограммы за это время явно не в ваше преимущество", "Но уровень лени уже вряд ли позволит вам сделать что-то в своей жизни. Остаётся только выворачивать в свою сторону некоторые минусы, что тоже без последствий не останется", "В вашем случае неподвижность в бою, далеко не недостаток. И у вас ещё есть способы это доказать", "Боль в ваших ранах утихает", "Вы разблокировали реген от отражения урона!"}
        },
        new string[][]
        {
            new string[] {"Вас одолевает грусть. Понимание, что вам всегда везёт меньше остальных разъедает вас изнутри","Но если задуматься, вашей удаче просто негде проявляться. Это же можно решить?","Вы чувствуете, что ваша карма наконец найдёт проявление","Вы разблокировали критические удары!"},
            new string[] {"Вы вспоминаете моменты из разных сражений. Вы осознаёте, что в рамках ваших возможностей совсем мал простор для тактических действий","Однажды простой расчёт действий наперёд может спасти вам жизнь. Но что-же вы можете сделать для этого?","Вы рассматриваете меч в ваших руках","Вы разблокировали бросок меча!"},
            new string[] {"Вы глядите в небо. Не смотря на то, что вы уже добились больших успехов, слишком много в них зависит от везения","Хотелось бы хоть как-то самому контролировать такие случайные моменты, но как же?", "Вы сжимаете кулаки", "Вы разблокировали ручные криты!"},
            new string[] {"Ваш взгляд завис на руках. Ваше тело сильно закалилось в боях за всё это время. Опасные раньше травмы сейчас вам не хуже обычной царапины","Но раз вы такой танк, интересно было бы использовать вашу живучесть не только в контексте оттягивания смерти","Кровь в вашем теле пульсирует","Вы разблокировали кровавые удары!"},
            new string[] {"Ваш глаз задёргался. Столько нервов было потрачено, сколько жизней забрано. Всё ради спасения человечества.","Вы и не против этой работы. Но вам толком и негде излить свою злость, нет никакой отдушины. Убийства такими не являются","Ваше дело правое, но ведь каждому надо иногда врезать по столу или по чъему-то лицу в какой-то мере.","Ваши руки затряслись","Вы разблокировали резкий взмах!"},
            new string[] {"Вы вспоминаете вашу последнюю битву. Со временем развития боевых навыков вы, кажется, совсем растеряли человечность", "Битвы теперь не каторга, битвы теперь удовольствие. Причинение боли другим теперь не кажется таким плохим сценарием.", "Вашу зверскую натуру невозможно исправить, дно пробито. Осталось только наконец извлекать максимальную пользу из ваших недостатков", "Вы нервно рассмеялись", "Ваши криты теперь регенерируют вас!"}
        },
        new string[][]
        {
            new string[] {"Вас посещает странное чувство. Вы начинаете замечать даже самые ненаглядные мелочи вокруг", "Настал тот момент, когда вы впервые чувствуете себя по настоящему живым","Вы разблокировали концентрацию!"},
            new string[] {"Какое чудо! Неожиданно для себя в вашу голову мигом проникли десятки мыслей и кладесь знаний","Вы вспомнили простейшие заклинания. Вы чувствуете, будто у вас открылось третье око","Вы разблокировали магию!"},
            new string[] {"Смотря вдаль вы понимаете, насколько непревзойдённой глупостью были многие ваши риски","Вы не можете защитить себя в битве. Но ведь это несправедливо, верно?","Должен быть вариант не сильным, но умным людям типа вас прикрыть ваше лицо от удара","Вас осенило...","Вы разблокировали заклинание колючего щита!"},
            new string[] {"Впервые за многое время вы ощутили реальное одиночество","Никто не был вам другом в этом путешествии, но ведь все достойны друзей","Вы задумались, как с помощью ваших инструментов получить себе друга и помощника","Вам вдали видится силуэт собаки...","Вы разблокировали заклинание призыва гончей!"},
            new string[] {"Вы грустите, осознавая, что далеко не всё в жизни способны успеть","Остальные будто превзошли вас в скорости выполнения любых действий","Раз уж вы неконкурентоспособный слоупок, есть же вариант, как замедлить остальных","Холодок прокрался по спине...","Вы разблокировали заклинание заморозки!"},
            new string[] {"Шрам на вашей руке начинает кровоточить. Все эти битвы в результате не доводят до добра", "Откуда-то вы знаете, что вы всегда найдёте помощь и вылечитесь. Но лучше избежать удара, чем потом лечиться, верно?", "Вы попытались связать свои знания физики, пространства, миропонимания и магию", "Вы чувствуете себя везде и нигде одновременно...", "Вы разблокировали заклинание суперпозиции!" }
        }
    };
                    byte a = 0;
                    byte b = 0;
                    if (artefact[3])
                    for (int i = 0; i < playerstat.Length; i ++)
                        playerstat[i] -= 5;
                    void readthis()
                    {
                        abilunlocks[a][b] = true;
                        for (int aa = 0; aa < messages[a][b].Length; aa++)
                        {
                            Console.Clear();
                            Console.WriteLine(messages[a][b][aa]);
                            Console.ReadLine();
                        }
                    }
                    if (playerstat[0] >= 5 && !abilunlocks[0][0])
                    {
                        a = 0;
                        b = 0;
                        readthis();
                    }
                    if (playerstat[0] >= 10 && !abilunlocks[0][1])
                    {
                        a = 0;
                        b = 1;
                        readthis();
                    }
                    if (playerstat[0] >= 20 && !abilunlocks[0][2])
                    {
                        a = 0;
                        b = 2;
                        readthis();
                    }
                    if (playerstat[0] >= 30 && !abilunlocks[0][3])
                    {
                        a = 0;
                        b = 3;
                        readthis();
                    }
                    if (playerstat[0] >= 40 && !abilunlocks[0][4])
                    {
                        a = 0;
                        b = 4;
                        readthis();
                    }
                    if (playerstat[0] >= 50 && !abilunlocks[0][5])
                    {
                        a = 0;
                        b = 5;
                        readthis();
                    }
                    if (playerstat[1] >= 5 && !abilunlocks[1][0])
                    {
                        a = 1;
                        b = 0;
                        readthis();
                    }
                    if (playerstat[1] >= 10 && !abilunlocks[1][1])
                    {
                        a = 1;
                        b = 1;
                        readthis();
                    }
                    if (playerstat[1] >= 20 && !abilunlocks[1][2])
                    {
                        a = 1;
                        b = 2;
                        readthis();
                    }
                    if (playerstat[1] >= 30 && !abilunlocks[1][3])
                    {
                        a = 1;
                        b = 3;
                        readthis();
                    }
                    if (playerstat[1] >= 40 && !abilunlocks[1][4])
                    {
                        a = 1;
                        b = 4;
                        readthis();
                    }
                    if (playerstat[1] >= 50 && !abilunlocks[1][5])
                    {
                        a = 1;
                        b = 5;
                        readthis();
                    }
                    if (playerstat[2] >= 5 && !abilunlocks[2][0])
                    {
                        a = 2;
                        b = 0;
                        readthis();
                    }
                    if (playerstat[2] >= 10 && !abilunlocks[2][1])
                    {
                        a = 2;
                        b = 1;
                        foundspell[1] = true;
                        foundspell[0] = true;
                        dopotionfind[1] = true;
                        readthis();
                    }
                    if (playerstat[2] >= 20 && !abilunlocks[2][2])
                    {
                        a = 2;
                        b = 2;
                        foundspell[2] = true;
                        readthis();
                    }
                    if (playerstat[2] >= 30 && !abilunlocks[2][3])
                    {
                        foundspell[3] = true;
                        a = 2;
                        b = 3;
                        readthis();
                    }
                    if (playerstat[2] >= 40 && !abilunlocks[2][4])
                    {
                        foundspell[4] = true;
                        a = 2;
                        b = 4;
                        readthis();
                    }
                    if (playerstat[2] >= 50 && !abilunlocks[2][5])
                    {
                        foundspell[5] = true;
                        a = 2;
                        b = 5;
                        readthis();
                    }
                    if (playerstat[0] >= playerstat[1] && playerstat[0] >= playerstat[2])
                        maxstat = 0;
                    else if (playerstat[1] >= playerstat[2] && playerstat[1] >= playerstat[0])
                        maxstat = 1;
                    else if (playerstat[2] >= playerstat[1] && playerstat[2] >= playerstat[0])
                        maxstat = 2;
                    if (artefact[3])
                        for (int i = 0; i < playerstat.Length; i++)
                            playerstat[i] += 5;
                }
                timetocamp();
            }
            void auto()
            {
                int auto0;
                auto0 = (choice - 1);
                string[] skill = { "живучести", "силы", "разума" };
                Console.Clear();
                Console.WriteLine("Введите желаемое количество улучшений на навык " + skill[auto0] + ", или выйдите введя любой символ");
                string iwannathisup = Console.ReadLine();
                bool isNum = int.TryParse(iwannathisup, out int wannathisup);
                if (isNum)
                {
                    if (wannathisup > upgradepoints)
                    {
                        Console.WriteLine("Вам не хватает очков улучшений для этого");
                        Console.ReadLine();
                        upgrademenu();
                    }
                    else if (wannathisup < 0)
                    {
                        Console.WriteLine("О нет, откатить изменения нельзя. Можно вводить только положительные значения");
                        Console.ReadLine();
                        upgrademenu();
                    }
                    playerstat[auto0] += wannathisup;
                    upgradepoints -= wannathisup;
                    int sst = 50;
                    if (artefact[3])
                        sst = 55;
                    for(int i = 0; i < playerstat.Length; i++)
                    {
                        if (playerstat[i] > sst)
                        {
                            upgradepoints += playerstat[i] - sst;
                            playerstat[i] -= playerstat[i] - sst;
                            Console.Clear();
                            Console.WriteLine("Вы уже достигли достигли совершенства в этом навыке");
                            Console.ReadLine();
                        }    
                    }
                    upgrademenu();
                }
                else
                {
                    upgrademenu();
                }
            }
        }
    }
    else if (playeraction == "3")
    {
        craftingpotion();
        void craftingpotion()
        {
            Console.Clear();
            Console.WriteLine("Выберите желаемый предмет: ");
            for (int aa = 0; aa < potionname.Length; aa++)
            {
                if (dopotionfind[aa])
                    Console.WriteLine("[" + (aa + 1) + "] " + potionname[aa]);
            }
            Console.WriteLine("[e] Выход");
            string playeraction = Console.ReadLine();
            bool isNum = int.TryParse(playeraction, out int choice);
            if (isNum)
            {
                int[][] potionneeds =
                {
            new int[]{3, 1,},
            new int[]{2, 1, 1, 0, 0, 0,},
            new int[]{0, 0, 1, 0, 2, 0, 0, 0, 0, 2},
            new int[]{0, 0, 0, 1, 0, 0, 0, 0, 3, 0, 2},
            new int[]{0, 0, 0, 0, 0, 3, 2},
            new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 1},
            new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 1, 2, 0},
        };
                string[] potionrecipe = { "Слизь (3), грязная палка", "Слизь (2), грязная палка, кроличий глаз", "Кроличий глаз, ткань (2), душа пограничности (2)", "Душа живучести, радиоактивная пыль (3), гниль (2)", "Съедобная руда (3), душа защиты (2)", "Стекло (2), электроника (2), Смарт-Врайтер 2.3", "Гниль (4), механический глаз, электроника (2)"};
                Console.Clear();
                if (choice > 0 && choice <= potionname.Length)
                {
                    string[] potioneffects =
{
                         "восстановление " + (30 + chlevel * 2) + " хп",
                         "восстановление " + (Convert.ToInt32(20 + (int)(chlevel) * 1.5)) + " маны",
                         "увеличение шанса уклонения в 3 раза на 3 хода",
                         "увеличение урона в полтара раза и увеличение шанса крита в 3 раза в течении 3 ходов",
                         "Починка брони в течении 3 ходов в 2,5 раза эффективнее",
                         "В течении 3 ходов параметры персонажа никак не будут меняться",
                         "DEC (разложение) граната создаёт облако газа вокруг противника, действующее 3 хода. С каждым ходом наносит в 2 раза больше урона, начиная с " + (5 + chlevel / 3) + "\nЭффект не складывается"
};
                    if (dopotionfind[choice - 1])
                    {
                        bool youhaveneeds = true;
                        Console.WriteLine("Эффект при использовании: " + potioneffects[choice - 1] + "\nТребуемые ингредиенты: " + potionrecipe[choice - 1] + "\nВы действительно хотите изготовить " + potionname[choice - 1] + "? \n          y - Да          n - нет");
                        playeraction = Console.ReadLine();
                        if (playeraction == "Y" || playeraction == "y")
                        {
                            for (int aa = 0; aa < potionneeds[0].Length; aa++)
                            {
                                if (potionneeds[choice - 1][aa] > craftitems[aa])
                                    youhaveneeds = false;
                            }
                            if (youhaveneeds)
                            {
                                for (int aa = 0; aa < potionneeds[0].Length; aa++)
                                {
                                    craftitems[aa] -= potionneeds[choice - 1][aa];
                                }
                                items[choice - 1]++;
                                Console.Clear();
                                Console.WriteLine("Вы создали " + potionname[choice - 1]);
                                Console.ReadLine();
                                craftingpotion();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("У вас не хватает ингредиентов");
                                Console.ReadLine();
                                craftingpotion();
                            }
                        }
                        else
                            craftingpotion();
                    }
                    else
                    {
                        Console.WriteLine("Данного расходника не существует");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Данного расходника не существует");
                    Console.ReadLine();

                }
                craftingpotion();
            }
            else timetocamp();

        }
    }
    else if (playeraction == "4")
        playerinventory();
    else if (inhub)
        hub();
    else
    {
        Console.Clear();
        Console.WriteLine("Неизвестное действие. Чтобы закончить событие лагеря, выберите вариант отдыха");
        Console.ReadLine();
        timetocamp();
    }
}
// Параметры битвы с врагами
void ImError()
{
    killtoreturn = 0;
    killtocamp = 0;
    Console.Clear();
    enemynmoglas = false;
    attackdelay = 3;
    enemyname = "Я - ошибка";
    description = "Ты вышел за рамки дозволенного";
    playerstep = 0;
    enemystrMAX = 5;
    enemymaxhp = 10;
    enemydef = -1;
    dodgechance = 0;
    xpgains[5][0] = 5; xpgains[5][1] = 0;
    enemyhp = enemymaxhp;
    enemystep();
}
// Поле
void SlimeFight()
{
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Слизень";
    description = "Склизкий и пахнет, как клей ПВА";
    playerstep = 0;
    enemystrMAX = 10;
    enemymaxhp = 30;
    enemydef = 0;
    dodgechance = 15;
    xpgains[5][0] = 0; xpgains[5][1] = 0;
    dropchance[0] = 65;
    enemyhp = enemymaxhp;
    enemystep();
}
void TumbleweedFight()
{
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Перекати-поле";
    description = "В этих ветках проглядывается жуткий взгляд с красным свечением";
    playerstep = 0;
    enemystrMAX = 9;
    enemymaxhp = 25;
    enemydef = 0;
    dodgechance = 30;
    xpgains[5][0] = 0; xpgains[5][1] = 1;
    dropchance[1] = 70;
    enemyhp = enemymaxhp;
    enemystep();
}
void RabbytkillerFight()
{
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Кролик убийца";
    description = "В здоровом теле вовсе не здоровый дух";
    playerstep = 0;
    enemystrMAX = 6;
    enemymaxhp = 21;
    enemydef = 0;
    dodgechance = 50;
    xpgains[5][0] = 0; xpgains[5][1] = 2;
    dropchance[2] = 33;
    enemyhp = enemymaxhp;
    enemystep();
}
void theTrollHearteaterFight()
{
    enemynmoglas = false;
    attackdelay = 3;
    enemyname = "Тролль сердцеед";
    description = "И нет, не в переносном смысле слова. Берегите свою грудь";
    playerstep = 0;
    enemystrMAX = 20;
    enemymaxhp = 60;
    enemydef = 0;
    dodgechance = 5;
    xpgains[5][0] = 0; xpgains[5][1] = 3;
    dropchance[1] = 40;
    dropchance[3] = 100;
    enemyhp = enemymaxhp;
    enemystep();
}
void UmbrellaSpider()
{
    enemynmoglas = false;
    attackdelay = 2;
    enemyname = "Паук с зонтиком";
    description = "Наконец они поняли, что атаковать спицами не столь эффективно. Теперь они предпочитают бить ручкой";
    playerstep = 0;
    enemystrMAX = 13;
    enemymaxhp = 15;
    enemydef = 5;
    dodgechance = 15;
    xpgains[5][0] = 0; xpgains[5][1] = 4;
    dropchance[4] = 65;
    dropchance[1] = 75;
    enemyhp = enemymaxhp;
    enemystep();
}
// Побережье
void rockfisherFight()
{
    dialogopt[0][3] = true;
    enemynmoglas = false;
    attackdelay = 2;
    enemyname = "Камневод";
    description = "Камневодит";
    playerstep = 0;
    enemystrMAX = 36;
    enemymaxhp = 120;
    enemydef = 10;
    dodgechance = 25;
    xpgains[5][0] = 1; xpgains[5][1] = 0;
    dropchance[5] = 40;
    dropchance[7] = 70;
    dialogopt[0][3] = true;
    enemyhp = enemymaxhp;
    enemystep();
}
void armacrabFight()
{
    enemynmoglas = false;
    attackdelay = 2;
    enemyname = "Краб броненосец";
    description = "Зачем ему пальцы, как у человека? Так ему удобнее заботиться о своём драгоценном панцире";
    playerstep = 0;
    enemystrMAX = 40;
    enemymaxhp = 100;
    enemydef = 25;
    dodgechance = 25;
    xpgains[5][0] = 1; xpgains[5][1] = 1;
    dropchance[6] = 100;
    enemyhp = enemymaxhp;
    enemystep();
}
void MummyFight()
{
    enemynmoglas = false;
    attackdelay = 3;
    enemyname = "Мумия";
    description = "От него так и веет мором... Старайтесь не касаться его бинтов";
    playerstep = 0;
    enemystrMAX = 60;
    enemymaxhp = 90;
    enemydef = 5;
    dodgechance = 33;
    xpgains[5][0] = 1; xpgains[5][1] = 2;
    dropchance[4] = 80;
    dropchance[10] = 35;
    enemyhp = enemymaxhp;
    enemystep();
}
void GoblinArmored()
{
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Гоблин в доспехах";
    description = "Консервы \"Завтрак дракона\"";
    playerstep = 0;
    enemystrMAX = 27;
    enemymaxhp = 70;
    enemydef = 30;
    dodgechance = 25;
    xpgains[5][0] = 1; xpgains[5][1] = 3;
    dropchance[6] = 10;
    dropchance[1] = 25;
    dropchance[5] = 15;
    enemyhp = enemymaxhp;
    enemystep();
}
void MonsterTentacle()
{
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Монстрическое щупальце";
    description = "Хм, в каком-же жанре вы это встречали? Даже не знаю...";
    playerstep = 0;
    enemystrMAX = 34;
    enemymaxhp = 150;
    enemydef = 0;
    dodgechance = 10;
    xpgains[5][0] = 1; xpgains[5][1] = 4;
    dropchance[5] = 15;
    enemyhp = enemymaxhp;
    enemystep();
}
// Пустошь
void twoheadedbearFight()
{
    enemynmoglas = false;
    attackdelay = 2;
    enemyname = "Двухголовый медведь";
    description = "Вы находитесь в Калифорнии? Или в Сибири? Плевать. Где-бы ты ни был, это место уже не будет таким, как прежде";
    playerstep = 0;
    enemystrMAX = 70;
    enemymaxhp = 250;
    enemydef = 6;
    dodgechance = 15;
    xpgains[5][0] = 2; xpgains[5][1] = 0;
    dropchance[6] = 0;
    dropchance[8] = 45;
    enemyhp = enemymaxhp;
    enemystep();
}
void GhoulTheRockerFight()
{
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Гуль рокер";
    description = "Проффесионально держит гитару в положении меча. Бравый воин";
    playerstep = 0;
    enemystrMAX = 34;
    enemymaxhp = 170;
    enemydef = 12;
    dodgechance = 45;
    xpgains[5][0] = 2; xpgains[5][1] = 1;
    dropchance[11] = 15;
    dropchance[10] = 100;
    fightwith[1] = true;
    enemyhp = enemymaxhp;
    enemystep();
}
void NecROMANcerFight()
{
    enemynmoglas = false;
    attackdelay = 3;
    enemyname = "НекРОМАНт";
    description = "Их давно уже запретили в твоей провинции. Тебе они не по нраву только потому, что они присматриваются к твоей самооценке";
    playerstep = 0;
    enemystrMAX = 100;
    enemymaxhp = 75;
    enemydef = 40;
    dodgechance = 30;
    xpgains[5][0] = 2; xpgains[5][1] = 2;
    dropchance[9] = 100;
    enemyhp = enemymaxhp;
    enemystep();
}
void CuteLittleGirlFight()
{
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Мёртвая девочка";
    description = "Пускай вершат над ней обряд – поют за упокой!";
    playerstep = 0;
    enemystrMAX = 40;
    enemymaxhp = 110;
    enemydef = 0;
    dodgechance = 50;
    xpgains[5][0] = 2; xpgains[5][1] = 3;
    dropchance[10] = 40;
    enemyhp = enemymaxhp;
    enemystep();
}
void MechaLizardScoutFight()
{
    if (dialogopt[0][13])
        GhoulTheRockerFight();
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Мехализард разведчик";
    description = "Неотвратимая участь пустошей приближается...";
    playerstep = 0;
    enemystrMAX = 50;
    enemymaxhp = 100;
    enemydef = 20;
    dodgechance = 20;
    xpgains[5][0] = 2; xpgains[5][1] = 4;
    dropchance[13] = 7;
    dropchance[12] = 10;
    dropchance[11] = 15;
    enemyhp = enemymaxhp;
    enemystep();
}
// Колония
void MechaLizardDrillerFight()
{
    if (dialogopt[0][13])
        StaticTurretFight();
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Мехализард буровик";
    description = "Он ещё слишком глуп, чтобы использовать свой бур, как оружие. Я сказал \"ещё\"? О нет. Он не поумнеет(";
    playerstep = 0;
    enemystrMAX = 80;
    enemymaxhp = 200;
    enemydef = 20;
    dodgechance = 20;
    xpgains[5][0] = 3; xpgains[5][1] = 0;
    dropchance[13] = 15;
    dropchance[12] = 20;
    dropchance[11] = 30;
    enemyhp = enemymaxhp;
    enemystep();
}
void MechaLizardMilitaryFight()
{
    if (dialogopt[0][13])
        StaticTurretFight();
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Мехализард Страж";
    description = "Почему Страж с большой буквы? У него так на бейджике написано. А ещё он настоящий убийца!";
    playerstep = 0;
    enemystrMAX = 90;
    enemymaxhp = 200;
    enemydef = 25;
    dodgechance = 15;
    xpgains[5][0] = 3; xpgains[5][1] = 1;
    dropchance[13] = 15;
    dropchance[12] = 20;
    dropchance[11] = 30;
    enemyhp = enemymaxhp;
    enemystep();
}
void MechaLizardControllerFight()
{
    if (dialogopt[0][13])
        TransportDroneFight();
    enemynmoglas = false;
    attackdelay = 2;
    enemyname = "Мехализард контролёр";
    description = "Он ничего не делает. За него и так всё контролируется, но давай умолчим об этом. Мы же не хотим, чтобы ему влетело от начальства?";
    playerstep = 0;
    enemystrMAX = 60;
    enemymaxhp = 200;
    enemydef = 40;
    dodgechance = 0;
    xpgains[5][0] = 3; xpgains[5][1] = 2;
    dropchance[13] = 15;
    dropchance[12] = 20;
    dropchance[11] = 30;
    enemyhp = enemymaxhp;
    enemystep();
}
void StaticTurretFight()
{
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Статичная турель";
    description = "Я ещё не видел никого умнее пули...";
    playerstep = 0;
    enemystrMAX = 40;
    enemymaxhp = 100;
    enemydef = 70;
    dodgechance = 0;
    xpgains[5][0] = 3; xpgains[5][1] = 2;
    dropchance[13] = 15;
    enemyhp = enemymaxhp;
    enemystep();
}
void TransportDroneFight()
{
    enemynmoglas = false;
    attackdelay = 4;
    enemyname = "Транспортный дрон";
    description = "На нём не единого оружия. С каких пор вы вообще решили, что он вам враг?";
    playerstep = 0;
    enemystrMAX = 0;
    enemymaxhp = 50;
    enemydef = 70;
    dodgechance = 0;
    xpgains[5][0] = 3; xpgains[5][1] = 2;
    fightwith[2] = true;
    dropchance[13] = 15;
    enemyhp = enemymaxhp;
    enemystep();
}
// Резиденция
void MechaLizardCreatorFight()
{
    if (dialogopt[0][13])
        LizardFight();
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Мехализард Творец";
    description = "Принуждённый к созданию во имя всеобщего разрушения. Такова цена почти любых животных удовольствий";
    playerstep = 0;
    enemystrMAX = 100;
    enemymaxhp = 200;
    enemydef = 50;
    dodgechance = 20;
    xpgains[5][0] = 4; xpgains[5][1] = 0;
    dropchance[13] = 15;
    dropchance[12] = 20;
    dropchance[11] = 30;
    enemyhp = enemymaxhp;
    enemystep();
}
void LizardFight()
{
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Лизард";
    description = "Олицетворение алчности, жестокости и самопровозглашённости. Твой долг - сделать из него фарш";
    playerstep = 0;
    enemystrMAX = 120;
    enemymaxhp = 300;
    enemydef = 20;
    dodgechance = 20;
    xpgains[5][0] = 4; xpgains[5][1] = 0;
    dropchance[14] = 40;
    dropchance[16] = 30;
    enemyhp = enemymaxhp;
    enemystep();
}
void LizardPropagandistFight()
{
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Лизард пропагандист";
    description = "Подавляет задатки появляющихся вопросов в и без того скромном разуме Мехализардов";
    playerstep = 0;
    enemystrMAX = 105;
    enemymaxhp = 280;
    enemydef = 25;
    dodgechance = 20;
    xpgains[5][0] = 4; xpgains[5][1] = 0;
    dropchance[14] = 20;
    dropchance[15] = 100;
    dropchance[16] = 30;
    enemyhp = enemymaxhp;
    enemystep();
}
void LizardMechanicFight()
{
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Лизард механик";
    description = "Понемногу совершенствует машины разрушения, созданные им ранее. Никакой физической работы, только отдача приказов и новых чертежей";
    playerstep = 0;
    enemystrMAX = 95;
    enemymaxhp = 220;
    enemydef = 30;
    dodgechance = 20;
    xpgains[5][0] = 4; xpgains[5][1] = 0;
    dropchance[14] = 20;
    dropchance[16] = 30;
    enemyhp = enemymaxhp;
    enemystep();
}
void LizardInformantFight()
{
    enemynmoglas = false;
    attackdelay = 1;
    enemyname = "Лизард информатор";
    description = "Очень уж занятым лизардам некогда следить за их колониями и производствами. Работа эта принадлежит ему";
    playerstep = 0;
    enemystrMAX = 125;
    enemymaxhp = 200;
    enemydef = 15;
    dodgechance = 20;
    xpgains[5][0] = 4; xpgains[5][1] = 0;
    dropchance[14] = 20;
    dropchance[15] = 100;
    dropchance[16] = 30;
    enemyhp = enemymaxhp;
    enemystep();
}
// Комната управления
void theSomething()
{
    fightwith[0] = true;
    enemynmoglas = false;
    attackdelay = 2;
    enemyname = "Нечто";
    description = "Последнее, что вы увидите";
    playerstep = 0;
    enemystrMAX = 150;
    enemymaxhp = 2000;
    enemydef = 0;
    dodgechance = 10;
    xpgains[5][0] = 6; xpgains[5][1] = 0;
    enemyhp = enemymaxhp;
    enemystep();
}