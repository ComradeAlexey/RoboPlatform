using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text log;
    public GameObject menuPanel;
    public static GameObject sMenu;
    public Image image;
    public Vector2 force;
    public byte[] m;//массив байтов, конкретно тут - два байта
    public Text recconect;
    public Button buttonrecconect;
    public string bits;
    public string bits_force;
    public bool isButton;
    public int yfl = 0, xfl = 0;
    public float yflf = 0, xflf = 0;
    public int yF, xF;
    public int r,l;
    public InputField inputField1, inputField2;
    public void CalcJoystic()//расчёт байтов
    {
        yF = Mathf.Abs((int)force.y);//считываем с вертикального джойстика и делаем модуль полученного числа


        xF = Mathf.Abs((int)force.x);//считываем с горизонтального джойстика и делаем модуль полученного числа

        if (yF > 0)//если больше нуля, то проводим следующие операции
        {
            yF += 31;//прибавляем 31(до минимума чтобы догнать по мощи) 
            yF = Mathf.Clamp(yF, 31, 255);//смотрим, чтобы не вышло за пределы, в противном случае, ставим один из пределов в качестве значения, если меньше 31, то ставим 31, если больше 255, ставим 255
        }
        if (xF > 0)//так же как и сверху, только для горизонта
        {
            xF += 31;
            xF = Mathf.Clamp(xF, 31, 255);
        }

        if (force.x > 0 & force.y != 0)//если горизонт больше 0, т.е. вправо, и верткаль не равна нулю, т.е. едем вперёд/назад
        {
            r = (int)(xF * 0.5f);//т.к. у нас это поворот, то умножаем на половину, дабы скорость поворота правого движка, была в два раза меньше левого, для поворота.
            r = (int)(r * 0.25f);//умножаем так же оба движка на 1/4, для того, чтобы вместилось значение в 6 бит(тут правый)
            yF = (int)(yF * 0.25f);//левый
            for (int i = 0; i < 6; i++)//в цикле проходимся по битам из переменных выше и заносим их в массив байтов (мощность движков)
            {
                if (TestPlugin.checkbit((byte)r, i) == 1)
                {
                    m[0] = TestPlugin.setbit(m[0], i);

                }
                else
                {
                    m[0] = TestPlugin.unsetbit(m[0], i);
                }
                if (TestPlugin.checkbit((byte)(yF), i) == 1)
                {
                    m[1] = TestPlugin.setbit(m[1], i);
                }
                else
                {
                    m[1] = TestPlugin.unsetbit(m[1], i);
                }
            }
            if (force.y > 0)//направление, если вперёд, то устанавливаем биты, иначе снимаем
            {
                m[0] = TestPlugin.setbit(m[0], 6);
                m[1] = TestPlugin.setbit(m[1], 6);
            }
            else
            {
                m[0] = TestPlugin.unsetbit(m[0], 6);
                m[1] = TestPlugin.unsetbit(m[1], 6);
            }
        }
        else if (force.x < 0 & force.y != 0)//аналогично вышестоящему коду, только наоборот
        {
            l = (int)(xF * 0.5f);
            l = (int)(l * 0.25f);
            yF = (int)(yF * 0.25f);
            for (int i = 0; i < 6; i++)
            {
                if (TestPlugin.checkbit((byte)yF, i) == 1)
                {
                    m[0] = TestPlugin.setbit(m[0], i);

                }
                else
                {
                    m[0] = TestPlugin.unsetbit(m[0], i);
                }
                if (TestPlugin.checkbit((byte)(l), i) == 1)
                {
                    m[1] = TestPlugin.setbit(m[1], i);
                }
                else
                {
                    m[1] = TestPlugin.unsetbit(m[1], i);
                }
            }
            if (force.y > 0)
            {

                m[0] = TestPlugin.setbit(m[0], 6);
                m[1] = TestPlugin.setbit(m[1], 6);
            }
            else
            {
                m[0] = TestPlugin.unsetbit(m[0], 6);
                m[1] = TestPlugin.unsetbit(m[1], 6);
            }
        }
        else if (force.x > 0 & force.y == 0)//если только горизонт, вправо
        {
            r = xF;//присваиваем горизонт переменной
            r = (int)(r * 0.25f);//делим на 4
            for (int i = 0; i < 6; i++)//так же мощность движкам задаём
            {
                if (TestPlugin.checkbit((byte)r, i) == 1)
                {
                    m[0] = TestPlugin.setbit(m[0], i);
                    m[1] = TestPlugin.setbit(m[1], i);
                }
                else
                {
                    m[0] = TestPlugin.unsetbit(m[0], i);
                    m[1] = TestPlugin.unsetbit(m[1], i);
                }
            }

            m[0] = TestPlugin.unsetbit(m[0], 6);//на всякий очищаем биты, и ставим на левый, направление назад
            m[1] = TestPlugin.unsetbit(m[1], 6);
            m[1] = TestPlugin.setbit(m[1], 6);//устанавливаем, на правый мотор направление вперёд
        }
        else if (force.x < 0 & force.y == 0)//аналогично тому, что выше, только наоборот
        {
            l = xF;
            l = (int)(l * 0.25f);
            for (int i = 0; i < 6; i++)
            {
                if (TestPlugin.checkbit((byte)l, i) == 1)
                {
                    m[0] = TestPlugin.setbit(m[0], i);
                    m[1] = TestPlugin.setbit(m[1], i);
                }
                else
                {
                    m[0] = TestPlugin.unsetbit(m[0], i);
                    m[1] = TestPlugin.unsetbit(m[1], i);
                }
            }

            m[0] = TestPlugin.unsetbit(m[0], 6);
            m[1] = TestPlugin.unsetbit(m[1], 6);
            m[0] = TestPlugin.setbit(m[0], 6);
        }
        else//если только вертикаль
        {
            yF = (int)(yF * 0.25f);//вертикаль присваиваем переменной
            for (int i = 0; i < 6; i++)//задаём мощь движкам
            {

                if (TestPlugin.checkbit((byte)yF, i) == 1)
                {
                    m[0] = TestPlugin.setbit(m[0], i);
                    m[1] = TestPlugin.setbit(m[1], i);
                }
                else
                {
                    m[0] = TestPlugin.unsetbit(m[0], i);
                    m[1] = TestPlugin.unsetbit(m[1], i);
                }
            }
            //задаём ориентацию движкам
            if (force.y > 0)
            {
                m[0] = TestPlugin.setbit(m[0], 6);
                m[1] = TestPlugin.setbit(m[1], 6);
            }
            else
            {
                m[0] = TestPlugin.unsetbit(m[0], 6);
                m[1] = TestPlugin.unsetbit(m[1], 6);
            }
        }
        try
        {
            m[2] = Convert.ToByte(inputField1.text);
            m[3] = Convert.ToByte(inputField2.text);
        }
        catch (Exception e)
        {

            
        }
        
        TestPlugin.SetMessage(m);//отправка смски)
        Debug.Log("Произошла отправка");
        GetMessage();
        
    }
    public void ExitListDevices()//выходим из списка устройств 
    {
        menuPanel.SetActive(false);
    }
    void Update()
    {
        TestPlugin.GetStatus(image);//получаем статус подключения устройства
    }
    void Awake()//стартовый метод, запускается самым первым при старте сцены
    {
        m = new byte[4];//инициализируем массив байтов
        TestPlugin.Init();//инициализируем джава класс
        sMenu = menuPanel;//инициализируем панель меню
        log.text = "0";//лог инициализируем
        if (PlayerPrefs.HasKey("Mac"))//если есть сохранённое устройство, приделываем его
        {
            if (!string.IsNullOrWhiteSpace(PlayerPrefs.GetString("Mac")))
            {
                recconect.text = "Переподключение";
                buttonrecconect.enabled = true;
            }
            else
            {
                recconect.text = "Нет сохранённых устройств";
                buttonrecconect.enabled = false;
            }
        }
        else
        {
            recconect.text = "Нет сохранённых устройств";
            buttonrecconect.enabled = false;
        }

        TestPlugin.GetStatus(image);//получаем статус подключения устройства

    }
    public void LVLLoad()//загрузка уровня с моделью платформы
    {
        SceneManager.LoadScene("model");
    }
    public void Recconnect()//производим переподключение
    {
        TestPlugin.Recconnect();
    }
    public void ShowDevaces()//показываем устройства которые обнаружил блютуз
    {
        TestPlugin.ShowDevaces();
    }
    public void Exit()//выходим из приложения
    {
        Application.Quit();
    }
    public void Kek()//ну кек это кек
    {
        TestPlugin.Kek(log);
    }
    public void Show()//показываем что-то, уже забыл что
    {
        TestPlugin.Show("Kek", log, image);
    }
    public void Right()//пустота, душевная
    {
           
    }
    public void Left()//так же
    {
        
    }
    public void Jump()//соленоид вкл
    {
        //задаём на 7 позиции биты
        m[1] = TestPlugin.unsetbit(m[1], 7);
        m[0] = TestPlugin.unsetbit(m[0], 7);
        m[1] = TestPlugin.setbit(m[1], 7);
        m[0] = TestPlugin.setbit(m[0], 7);
        TestPlugin.SetMessage(m);
        Debug.Log("Произошла отправка");
    }
    public void UnJump()//соленоид выкл 
    {
        //убираем биты с 7 позиции
        m[1] = TestPlugin.unsetbit(m[1], 7);
        m[0] = TestPlugin.unsetbit(m[0], 7);
        TestPlugin.SetMessage(m);
        Debug.Log("Произошла отправка");
    }
    public void ShowDeviceName()//не помню
    {
        TestPlugin.ShowDeviceName(log);
    }
    public void OpenMenu()//открытие меню
    {
        menuPanel.SetActive(true);
    }
    public void CloseMenu()//закрытие меню
    {
        menuPanel.SetActive(false);
    }
    public void GetMessage()
    {
        log.text = TestPlugin.GetMessage();
    }
    public class TestPlugin//класс для работы с джава плагином
    {
        private const string NAME_CLASS = "com.example.bluetoothplugin.BluetoothPlugin";
        private static AndroidJavaClass jC;
        public static void Init()//инициализация
        {
            jC = new AndroidJavaClass(NAME_CLASS);
            jC.CallStatic("Init");
        }
        public static void Show(string text, Text log, Image image)//показываем поиск устройств
        {
            log.text = jC.ToString();
            if (jC != null)
            {
                jC.CallStatic("searchDevices");
            }
            else log.text = "null!!!";
        }
        public static void ShowDevaces()//показываем все девайсы
        {
            jC.CallStatic("showListDevices");
        }
        public static string GetMessage()//поулчаем месседж(для будущего затычка)
        {
            return jC.CallStatic<int>("getMessage").ToString();
        }
        public static void ShowDeviceName(Text log)//получаем имя устройства
        {
            log.text = jC.CallStatic<string>("getNameDevice", 0);
        }
        public static void Kek(Text log)//кек
        {
            log.text = jC.CallStatic<int>("ReturnCountDevices").ToString();
        }
        static public byte checkbit(byte value, int position)//чекаем бит
        {
            byte result;
            if ((value & (1 << position)) == 0)
            {
                result = 0;
            }
            else
            {
                result = 1;
            }
            return result;
        }

        static public byte setbit(byte value, int position)//устанавливаем бит в 1
        {
            return (byte)(value | (1 << position));
        }

        static public byte unsetbit(byte value, int position)//устанавливаем бит в 0
        {
            return (byte)(value & ~(1 << position));
        }
        public static void SetMessage(byte[] m)//отправляем смску 
        {

            jC.CallStatic("setMessage", m);
        }

        public static void Recconnect()//переподключение
        {
            jC.CallStatic("Recconnect", PlayerPrefs.GetString("Mac"));
        }
        internal static void GetStatus(Image image)//статус устройства
        {
            if (jC.CallStatic<string>("GetStatus") == "Подключение прошло успешно!")
            {
                image.color = Color.green;
                string mac = jC.CallStatic<string>("GetMac");
                PlayerPrefs.SetString("Mac", mac);
            }
            else
            {
                image.color = Color.red;
            }
        }
    }
}
