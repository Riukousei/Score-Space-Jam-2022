using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class UpgradeMenu : MonoBehaviour
{

    public bool offScreen = true;
    [SerializeField] private GameObject offScreenTarget,onScreenTarget,upgradeMenu;
    public Transform target;
    public float startTimeScale,speed;

    public Score scoreboard;
    public PlayerHealth PH;
    public PlayerAttacks PA;
    public PlayerMovement PM;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Tab();
        }

        upgradeMenu.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(upgradeMenu.GetComponent<RectTransform>().anchoredPosition, target.GetComponent<RectTransform>().anchoredPosition, Time.unscaledTime * speed);


    }
    public void Tab()
    {
        if (offScreen == true)
        {
            target = onScreenTarget.transform;
            Time.timeScale = 0;
            offScreen = !offScreen;
        }
        else
        {
            target = offScreenTarget.transform;
            Time.timeScale = startTimeScale;
            offScreen = !offScreen;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    [SerializeField] private int costoComprarVida,vidaExtraAlComprar;
    [SerializeField] private TextMeshProUGUI textoCostoComprarVida,textoVidaActual,textoVidaNueva;


    public void comprarVida()
    {
        if (scoreboard.points > costoComprarVida)
        {
            scoreboard.removePoints(costoComprarVida);
            PH.maxHealth += vidaExtraAlComprar;
            costoComprarVida = Mathf.RoundToInt(costoComprarVida * 1.2f);
            textoCostoComprarVida.text = costoComprarVida.ToString();
            textoVidaActual.text = PH.maxHealth.ToString();
            textoVidaNueva.text = (PH.maxHealth + vidaExtraAlComprar).ToString();
        }
    }

    [SerializeField] private int costoComprarRegen;
    [SerializeField] private float regenExtraAlComprar;
    [SerializeField] private TextMeshProUGUI textoCostoComprarRegen,textoRegenActual,textoRegenNueva;
    public void comprarRegen()
    {
        if (scoreboard.points > costoComprarRegen)
        {
            scoreboard.removePoints(costoComprarRegen);
            PH.regenSpeed += regenExtraAlComprar;
            costoComprarRegen = Mathf.RoundToInt(costoComprarVida * 1.3f);
            textoCostoComprarRegen.text = costoComprarRegen.ToString();
            textoRegenActual.text = PH.regenSpeed.ToString();
            textoRegenNueva.text = (PH.regenSpeed + regenExtraAlComprar).ToString();
        }
    }
    [SerializeField] private int costoComprarLaserDMG, laserDMGExtraAlComprar;
    [SerializeField] private TextMeshProUGUI textoCostoComprarLaserDMG, textoLaserDMGActual, textoLaserDMGNuevo;
    public void comprarLaserDMG()
    {
        if (scoreboard.points > costoComprarLaserDMG)
        {
            scoreboard.removePoints(costoComprarLaserDMG);
            PA.shootDamage += laserDMGExtraAlComprar;
            costoComprarLaserDMG = Mathf.RoundToInt(costoComprarLaserDMG * 1.2f);
            textoCostoComprarLaserDMG.text = costoComprarLaserDMG.ToString();
            textoLaserDMGActual.text = PA.shootDamage.ToString();
            textoLaserDMGNuevo.text = (PA.shootDamage + laserDMGExtraAlComprar).ToString();
        }
    }
    [SerializeField] private int costoComprarKatanaDMG, katanaDMGExtraAlComprar;
    [SerializeField] private TextMeshProUGUI textoCostoComprarKatanaDMG, textoKatanaDMGActual, textoKatanaDMGNuevo;
    public void comprarKatanaDMG()
    {
        if (scoreboard.points > costoComprarKatanaDMG)
        {
            scoreboard.removePoints(costoComprarKatanaDMG);
            PA.meleeDamage += katanaDMGExtraAlComprar;
            costoComprarKatanaDMG = Mathf.RoundToInt(costoComprarKatanaDMG * 1.3f);
            textoCostoComprarKatanaDMG.text = costoComprarKatanaDMG.ToString();
            textoKatanaDMGActual.text = PA.meleeDamage.ToString();
            textoKatanaDMGNuevo.text = (PA.meleeDamage + katanaDMGExtraAlComprar).ToString();
        }
    }
    [SerializeField] private int costoComprarSpeed;
    [SerializeField] private float speedExtraAlComprar;
    [SerializeField] private TextMeshProUGUI textoCostoComprarSpeed, textoSpeedActual, textoSpeedNuevo;

    public void comprarSpeed()
    {
        if (scoreboard.points > costoComprarSpeed)
        {
            scoreboard.removePoints(costoComprarSpeed);
            PM.speed += speedExtraAlComprar;
            costoComprarSpeed = Mathf.RoundToInt(costoComprarSpeed * 1.3f);
            textoCostoComprarSpeed.text = costoComprarSpeed.ToString();
            textoSpeedActual.text = PM.speed.ToString();
            textoSpeedNuevo.text = (PM.speed + speedExtraAlComprar).ToString();
        }
    }
    [SerializeField] private int costoComprarBullets, bulletsExtraAlComprar;
    [SerializeField] private TextMeshProUGUI textoCostoComprarBullets, textoBulletsActual, textoBulletsNuevo;
    public void comprarBullets()
    {
        if (scoreboard.points > costoComprarBullets)
        {
            scoreboard.removePoints(costoComprarBullets);
            PA.maxBullets += bulletsExtraAlComprar;
            PA.updateMaxBulletCount();
            costoComprarBullets = 2 * costoComprarBullets;
            textoCostoComprarBullets.text = costoComprarBullets.ToString();
            textoBulletsActual.text = PA.maxBullets.ToString();
            textoBulletsNuevo.text = (PA.maxBullets + bulletsExtraAlComprar).ToString();
        }
    }
    [SerializeField] private int costoComprarSCOREM;
    [SerializeField] private float SCOREMExtraALComprar;
    [SerializeField] private TextMeshProUGUI textoCostoComprarSCOREM, textoSCOREMActual, textoSCOREMNuevo;
    public void comprarSCOREM()
    {
        if (scoreboard.points > costoComprarSCOREM)
        {
            scoreboard.removePoints(costoComprarSCOREM);
            scoreboard.scoreM += SCOREMExtraALComprar;
            costoComprarSCOREM = Mathf.RoundToInt(costoComprarSCOREM * 1.2f);
            textoCostoComprarSCOREM.text = costoComprarSCOREM.ToString();
            textoSCOREMActual.text = scoreboard.scoreM.ToString();
            textoSCOREMNuevo.text = (scoreboard.scoreM + SCOREMExtraALComprar).ToString();
        }
    }

    void Start()
    {
        startTimeScale = Time.timeScale;
        target = offScreenTarget.transform;

        textoCostoComprarSCOREM.text = costoComprarSCOREM.ToString();
        textoSCOREMActual.text = scoreboard.scoreM.ToString();
        textoSCOREMNuevo.text = (scoreboard.scoreM + SCOREMExtraALComprar).ToString();

        textoCostoComprarBullets.text = costoComprarBullets.ToString();
        textoBulletsActual.text = PA.maxBullets.ToString();
        textoBulletsNuevo.text = (PA.maxBullets + bulletsExtraAlComprar).ToString();

        textoCostoComprarSpeed.text = costoComprarSpeed.ToString();
        textoSpeedActual.text = PM.speed.ToString();
        textoSpeedNuevo.text = (PM.speed + speedExtraAlComprar).ToString();

        textoCostoComprarKatanaDMG.text = costoComprarKatanaDMG.ToString();
        textoKatanaDMGActual.text = PA.meleeDamage.ToString();
        textoKatanaDMGNuevo.text = (PA.meleeDamage + katanaDMGExtraAlComprar).ToString();

        textoCostoComprarRegen.text = costoComprarRegen.ToString();
        textoRegenActual.text = PH.regenSpeed.ToString();
        textoRegenNueva.text = (PH.regenSpeed + regenExtraAlComprar).ToString();

        textoCostoComprarVida.text = costoComprarVida.ToString();
        textoVidaActual.text = PH.maxHealth.ToString();
        textoVidaNueva.text = (PH.maxHealth + vidaExtraAlComprar).ToString();

        textoCostoComprarLaserDMG.text = costoComprarLaserDMG.ToString();
        textoLaserDMGActual.text = PA.shootDamage.ToString();
        textoLaserDMGNuevo.text = (PA.shootDamage + laserDMGExtraAlComprar).ToString();
    }
}
