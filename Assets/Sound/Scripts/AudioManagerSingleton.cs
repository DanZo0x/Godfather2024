using UnityEngine;

public class AudioManagerSingleton : MonoBehaviour
{
    /*
    [Range(0f, 1f)]
    [SerializeField]
    private float
        _missileVol,
        _starGainVol,
        _UIClickVol,
        _UIZapVol,
        _UIstarVol,
        _UIlevelDoneVol,
        _musicVol,
        _powerUpVol,
        _enoughStarsVol,
        _failureVol,
        _sucessVol;

    [Range(0f, 3f)]
    [SerializeField]
    private float _negativeVol;

    [Range(0f, 2f)]
    [SerializeField]
    private float[] _beepVol;
    */

    public AudioSource BatimentDestroy;
    public AudioSource LaserLoop;
    public AudioSource RobotStepLoop;
    public AudioSource TirAlt;
    public AudioSource TirLaser;
    public AudioSource TirMuted;

    public static AudioManagerSingleton Instance;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(this); }
    }

    /*
    public void MuteAudio(bool enabled)
    {
        MissileBeep.volume = enabled ? _missileVol : 0;
        Negative.volume = enabled ? _negativeVol : 0;
        StarGain.volume = enabled ? _starGainVol : 0;
        UIClick.volume = enabled ? _UIClickVol : 0;
        UIZap.volume = enabled ? _UIZapVol : 0;
        UIStar.volume = enabled ? _UIstarVol : 0;
        UILevelDone.volume = enabled ? _UIlevelDoneVol : 0;
        PowerUp.volume = enabled ? _powerUpVol : 0;
        EnoughStars.volume = enabled ? _enoughStarsVol : 0;
        Failure.volume = enabled ? _failureVol : 0;
        Success.volume = enabled ? _sucessVol : 0;
        for (int i = 0; i < CrystalPop.Length; i++)
        {
            CrystalPop[i].volume = enabled ? _beepVol[i] : 0;
        }
    }

    public void MuteMusic(bool enabled)
    {
        Music.volume = enabled ? _musicVol : 0;
    }
    */
}
