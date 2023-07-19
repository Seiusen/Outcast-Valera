using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathLog : MonoBehaviour
{
    [SerializeField] public AudioSource hitDieSound;
    [SerializeField] public AudioSource euSound;
    [SerializeField] public AudioSource windowBreakSound;
    public static string deathLog;
    public Text logText;
    public static int gameOver = 0;
    List<string> listHitDie = new List<string> {"Ноги отказали, спать не могу, жить не хочется. Валера наложил на себя руки", "Мужики не оценили поступок и запинали Валеру", "Уснул во дворе, загрызла собака", "Забили мужики за долги", "Валера не принес деньги и мужики решили проучить его. Отравился паленкой и остался лежать один, загрызла собака", "Уснул на путях", "Потерял сознание от голода и упал под поезд", "Оказалось нечем заплатить, забрали почки", "Не успел увернуться от удара в драке", "Подрался пьяным, умер от ножевого", "Предложили отработать долг уборщиком, но сил было настолько мало, что даже этого не смог. Зарезали", "Оказалось нечем заплатить и отбиться", "Алкоголь до добра не довел, уснул в баре, труп выкинули утром на улицу", "Приняли за бомжа и устроили поножовщину", "Уснул с вилкой в руке и проткнул себе глаз"};
    List<string> listEu = new List<string> {"Алкоголь до добра не довел, спился", "Отравился водкой и уснул в рвоте", "Уснул на лавочке, мужики раздели догола, забрав все, и оставили умирать от холода", "Печень не выдержала", "Так давно не ел, что сил идти нет, еще и столько не спал. Валера замерз насмерть около метро", "У Валеры отказали ноги, не в силах тащить себя руками, умер от жажды и голода", "Продали бодягу с просрочкой", "Увидел крысу на улице, съел и заразился бешенством", "Не сплю три дня из-за разрывающей боли от язвы, все из-за этого доширака. Лучше я сдохну! Валера повесился", "Боли в животе сводят с ума, теперь еще и есть не могу. Умер от голода", "Захлебнулся в пене изо рта", "Умер от язвы", "Снова этот доширак! Повесился с горя", "Уснул лицом в дошираке, задохнулся", "Зачем я живу, если даже спать плохо? Валера повесился"};
    List<string> listWindowBreak = new List<string> {"Я устал от такой жизни, 20 лет в никуда. Прыгнул из окна", "Случайно выпал из окна", "Валера оказался настолько уставшим, что забыл на каком этаже живет и прыгнул в окно за голубем"};

    void Start() {
        logText = GetComponent<Text>();

        if(listHitDie.Contains(deathLog))
            {
                if(PlayerPrefs.HasKey("soundsVol"))
                {
                    hitDieSound.volume = PlayerPrefs.GetFloat("soundsVol");
                    hitDieSound.Play();
                }
                else
                {
                    hitDieSound.volume = 1f;
                    hitDieSound.Play();
                }
            }

            if(listEu.Contains(deathLog))
            {
                if(PlayerPrefs.HasKey("soundsVol"))
                {
                    euSound.volume = PlayerPrefs.GetFloat("soundsVol");
                    euSound.Play();
                }
                else
                {
                    euSound.volume = 1f;
                    euSound.Play();
                }
            }

            if(listWindowBreak.Contains(deathLog))
            {
                if(PlayerPrefs.HasKey("soundsVol"))
                {
                    windowBreakSound.volume = PlayerPrefs.GetFloat("soundsVol");
                    windowBreakSound.Play();
                }
                else
                {
                    windowBreakSound.volume = 1f;
                    windowBreakSound.Play();
                }
            }
    }

    void Update() {
        if(gameOver == 1)
        {
            logText.text = deathLog;

            
        }
    }

}
