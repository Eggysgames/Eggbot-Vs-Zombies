using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour {

	private Main maincode; 
	private ShootingGuns shootingcode;
	private GunUISprites thegunscode;
	private GunUISprites frame1code;
	private GunUISprites frame2code;
	private GunUISprites frame3code;
	private GunUISprites frame4code;
	private GunUISprites frame5code;
	private GunUISprites pistolsequippedui; 
	private GunUISprites smgsequippedui; 
	private GunUISprites riflesequippedui; 
	private GunUISprites heavyequippedui; 
	private GunUISprites grenadesequippedui; 
	private GunFrame gunframecode;
	private GunFrame gunframe2code;
	private GunFrame gunframe3code;
	private GunFrame gunframe4code;
	private GunFrame gunframe5code;
	private Fading fadingcode;
	private GunBox gunboxcode;
	private int priceholder;
	private string selectedgun;
	private Character playercode;

	public GameObject infotext;
	public GameObject equiptext;
	public GameObject ReviveOMatic;
	public GameObject equipbutton;
	public GameObject uihud;
	public GameObject hudsgrenade;
	public GameObject theshop;
	public int money;
	public Text moneyui;
	public Text buypriceui;
	public GameObject theguns;
	public GameObject upgradebutton;
	public GameObject price;
	public GameObject door1;
	public GameObject door2;
	public GameObject door3;
	public GameObject door4;
	public GameObject door5;
	public GameObject door6;
	public GameObject door7;
	public GameObject frame1;
	public Text overlaytext1;
	public Text overlaytext2;
	public Text overlaytext3;
	public Text overlaytext4;
	public Text overlaytext5;
	public Text overlaytext6;
	public Text overlaytext7;
	public Text frame1text; 
	public Text frame2text; 
	public Text frame3text; 
	public Text frame4text;
	public Text frame5text;
	public Text pistolstextui;
	public Text smgstextui;
	public Text riflestextui;
	public Text heavytextui;
	public Text grenadestextui;
	public GameObject buysidebar;
	public GameObject Equippage;
	public GameObject pistolspage;
	public GameObject smgpage;
	public GameObject riflepage;
	public GameObject heavypage;
	public GameObject grenadespage;
	public GameObject boxpage;
	public GameObject chatbox;

	public GameObject czlock;
	public GameObject autolock;
	public GameObject revolverlock;
	public GameObject mp5lock;
	public GameObject spectrelock;
	public GameObject umplock;
	public GameObject p90lock;
	public GameObject galilock;
	public GameObject famaslock;
	public GameObject sglock;
	public GameObject m4a1lock;
	public GameObject rocketlock;
	public GameObject molotovlock;
	public GameObject bigsniperlock;
	public GameObject handturretlock;
	public GameObject shotgunlock;
	public GameObject antigravlock;


	public bool isvisible = true;
	public bool glockpurchased = true;
	public bool barettapurchased = true;
	public bool czpurchased = false;
	public bool autopurchased = false;
	public bool revolverpurchased = false;
	public bool mac10purchased = true;
	public bool mp5purchased = false;
	public bool spectrepurchased = false;
	public bool umppurchased = false;
	public bool p90purchased = false;
	public bool xm8purchased = true;
	public bool galipurchased = false;
	public bool famaspurchased = false;
	public bool sgpurchased = false;
	public bool m4a1purchased = false;
	public bool m32purchased = true;
	public bool rocketpurchased = false;
	public bool hegrenadepurchased = true;
	public bool	molotovpurchased = false;
	public bool awppurchased = true;
	public bool bigbessypurchased = true;
	public bool laserpurchased = true;
	public bool bigsniperpurchased = false;
	public bool handturretpurchased = false;
	public bool shotgunpurchased = false;
	public bool antigravpurchased = false;

	public int barettaprice = 50;
	public int czprice = 100;
	public int autopistolprice = 200;
	public int revolverprice = 300;
	public int mac10price = 400;
	public int mp5price = 500;
	public int spectreprice = 600;
	public int umpprice = 700;
	public int p90price = 800;
	public int xm8price = 900;
	public int galiprice = 1000;
	public int famasprice = 1100;
	public int sgprice = 1200;
	public int m4a1price = 1300;
	public int m32price = 1300;
	public int rocketprice = 1300;
	public int hegrenadeprice = 200;
	public int molotovprice = 500;

	public int awpprice = 1500;
	public int bigbessyprice = 1500;
	public int laserprice = 1500;
	public int bigsniperprice = 1500;
	public int handturretprice = 2000;
	public int shotgunprice = 2300;
	public int antigravprice = 5000;

	public AudioSource beep;

	void Start () {



		money = PlayerPrefs.GetInt ("Money");
		//PlayerPrefs.DeleteAll();

		pageson ();
		moneyui.text = "$" + money.ToString ();
		upgradebutton.GetComponent<Image> ().enabled = false;
		price.GetComponent<Text> ().enabled = false;
		maincode = GameObject.Find ("Main Camera").GetComponent<Main> ();
		shootingcode = GameObject.Find ("ArmGun").GetComponent<ShootingGuns> ();
		thegunscode = GameObject.Find ("UIGunsBuyingOnly").GetComponent<GunUISprites> ();
		frame1code = GameObject.Find ("GunsOnFrame1").GetComponent<GunUISprites> ();
		frame2code = GameObject.Find ("GunsOnFrame2").GetComponent<GunUISprites> ();
		frame3code = GameObject.Find ("GunsOnFrame3").GetComponent<GunUISprites> ();
		frame4code = GameObject.Find ("GunsOnFrame4").GetComponent<GunUISprites> ();
		frame5code = GameObject.Find ("GunsOnFrame5").GetComponent<GunUISprites> ();
		gunframecode = GameObject.Find ("GunFrame1").GetComponent<GunFrame> ();
		gunframe2code = GameObject.Find ("GunFrame2").GetComponent<GunFrame> ();
		gunframe3code = GameObject.Find ("GunFrame3").GetComponent<GunFrame> ();
		gunframe4code = GameObject.Find ("GunFrame4").GetComponent<GunFrame> ();
		gunframe5code = GameObject.Find ("GunFrame5").GetComponent<GunFrame> ();
		pistolsequippedui = GameObject.Find ("PistolsEquipped").GetComponent<GunUISprites> ();
		smgsequippedui = GameObject.Find ("SMGSEquipped").GetComponent<GunUISprites> ();
		riflesequippedui = GameObject.Find ("RiflesEquipped").GetComponent<GunUISprites> ();
		heavyequippedui = GameObject.Find ("HeavyEquipped").GetComponent<GunUISprites> ();
		grenadesequippedui = GameObject.Find ("GrenadesEquipped").GetComponent<GunUISprites> ();
		gunboxcode = GameObject.Find ("GunBox").GetComponent<GunBox> ();
		playercode = GameObject.Find ("EggHead").GetComponent<Character> ();
		fadingcode = GameObject.Find ("FadingEnd").GetComponent<Fading> ();
		pagesoff ();
		Equippage.SetActive (true);
		barettapurchased = true;
		mac10purchased = true;
		xm8purchased = true;
		m32purchased = true;
		awppurchased = true;
		infotext.SetActive (false);
		///
		czpurchased = (PlayerPrefs.GetInt ("czpurchased") != 0);
		czlock.GetComponent<Image> ().enabled = !czpurchased;
		autopurchased = (PlayerPrefs.GetInt ("autopurchased") != 0);
		autolock.GetComponent<Image> ().enabled = !autopurchased;
		revolverpurchased = (PlayerPrefs.GetInt ("revolverpurchased") != 0);
		revolverlock.GetComponent<Image> ().enabled = !revolverpurchased;
		mp5purchased = (PlayerPrefs.GetInt ("mp5purchased") != 0);
		mp5lock.GetComponent<Image> ().enabled = !mp5purchased;
		spectrepurchased = (PlayerPrefs.GetInt ("spectrepurchased") != 0);
		spectrelock.GetComponent<Image> ().enabled = !spectrepurchased;
		umppurchased = (PlayerPrefs.GetInt ("umppurchased") != 0);
		umplock.GetComponent<Image> ().enabled = !umppurchased;
		p90purchased = (PlayerPrefs.GetInt ("p90purchased") != 0);
		p90lock.GetComponent<Image> ().enabled = !p90purchased;
		galipurchased = (PlayerPrefs.GetInt ("galipurchased") != 0);
		galilock.GetComponent<Image> ().enabled = !galipurchased;
		famaspurchased = (PlayerPrefs.GetInt ("famaspurchased") != 0);
		famaslock.GetComponent<Image> ().enabled = !famaspurchased;
		sgpurchased = (PlayerPrefs.GetInt ("sgpurchased") != 0);
		sglock.GetComponent<Image> ().enabled = !sgpurchased;
		m4a1purchased = (PlayerPrefs.GetInt ("m4a1purchased") != 0);
		m4a1lock.GetComponent<Image> ().enabled = !m4a1purchased;
		rocketpurchased = (PlayerPrefs.GetInt ("rocketpurchased") != 0);
		rocketlock.GetComponent<Image> ().enabled = !rocketpurchased;
		molotovpurchased = (PlayerPrefs.GetInt ("molotovpurchased") != 0);
		molotovlock.GetComponent<Image> ().enabled = !molotovpurchased;
		bigsniperpurchased = (PlayerPrefs.GetInt ("bigsniperpurchased") != 0);
		bigsniperlock.GetComponent<Image> ().enabled = !bigsniperpurchased;
		gunboxcode.bigsniperpurchased = bigsniperpurchased;
		handturretpurchased = (PlayerPrefs.GetInt ("handturretpurchased") != 0);
		handturretlock.GetComponent<Image> ().enabled = !handturretpurchased;
		gunboxcode.handturretpurchased = handturretpurchased;
		shotgunpurchased = (PlayerPrefs.GetInt ("shotgunpurchased") != 0);
		shotgunlock.GetComponent<Image> ().enabled = !shotgunpurchased;
		gunboxcode.shotgunpurchased = shotgunpurchased;
		antigravpurchased = (PlayerPrefs.GetInt ("antigravpurchased") != 0);
		antigravlock.GetComponent<Image> ().enabled = !antigravpurchased;
		gunboxcode.antigravpurchased = antigravpurchased;
		///

		if (PlayerPrefs.GetInt ("frame1guntype") != 0) {
			frame1code.guntype = PlayerPrefs.GetInt ("frame1guntype");
			gunframecode.framegun = PlayerPrefs.GetInt ("gunframecode");
		}
		if (PlayerPrefs.GetInt ("frame1guntype") == 0) {
			frame1code.guntype = 1;
			gunframecode.framegun = 1;
		}
			
		if (PlayerPrefs.GetInt ("frame2guntype") != 0) {
			frame2code.guntype = PlayerPrefs.GetInt ("frame2guntype");
			gunframe2code.framegun = PlayerPrefs.GetInt ("gunframe2code");
		}
		if (PlayerPrefs.GetInt ("frame2guntype") == 0) {
			frame2code.guntype = 0;
			gunframe2code.framegun = 5;
		}

		if (PlayerPrefs.GetInt ("frame3guntype") != 0) {
			frame3code.guntype = PlayerPrefs.GetInt ("frame3guntype");
			gunframe3code.framegun = PlayerPrefs.GetInt ("gunframe3code");
		}
		if (PlayerPrefs.GetInt ("frame3guntype") == 0) {
			frame3code.guntype = 0;
			gunframe3code.framegun = 10;
		}

		if (PlayerPrefs.GetInt ("frame4guntype") != 0) {
			frame4code.guntype = PlayerPrefs.GetInt ("frame4guntype");
			gunframe4code.framegun = PlayerPrefs.GetInt ("gunframe4code");
		}
		if (PlayerPrefs.GetInt ("frame4guntype") == 0) {
			frame4code.guntype = 0;
			gunframe4code.framegun = 15;
		}

		if (PlayerPrefs.GetInt ("frame5guntype") != 0) {
			frame5code.guntype = PlayerPrefs.GetInt ("frame5guntype");
			gunframe5code.framegun = PlayerPrefs.GetInt ("gunframe5code");
		}
		if (PlayerPrefs.GetInt ("frame5guntype") == 0) {
			frame5code.guntype = 0;
			gunframe5code.framegun = 17;
		}



		frame1code.switchweaponssprites ();
		frame2code.switchweaponssprites ();
		frame3code.switchweaponssprites ();
		frame4code.switchweaponssprites ();
		frame5code.switchweaponssprites ();

		pressequip ();

		if (frame1code.guntype == 1) {
			frame1text.text = "Beretta";
		}
		if (frame1code.guntype == 2) {
			frame1text.text = "CZ-75";
		}
		if (frame1code.guntype == 3) {
			frame1text.text = "Auto";
		}
		if (frame1code.guntype == 4) {
			frame1text.text = "Revolver";
		}
		if (frame2code.guntype == 0) {
			frame2text.text = "Mac-10";
		}
		if (frame2code.guntype == 1) {
			frame2text.text = "MP5";
		}
		if (frame2code.guntype == 2) {
			frame2text.text = "Spectre";
		}
		if (frame2code.guntype == 3) {
			frame2text.text = "Ump";
		}
		if (frame2code.guntype == 4) {
			frame2text.text = "P90";
		}
		if (frame3code.guntype == 0) {
			frame3text.text = "XM-8";
		}
		if (frame3code.guntype == 1) {
			frame3text.text = "Gali";
		}
		if (frame3code.guntype == 2) {
			frame3text.text = "Famas";
		}
		if (frame3code.guntype == 3) {
			frame3text.text = "SG";
		}
		if (frame3code.guntype == 4) {
			frame3text.text = "M4A1";
		}
		if (frame4code.guntype == 0) {
			frame4text.text = "M32";
		}
		if (frame4code.guntype == 1) {
			frame4text.text = "Rocket";
		}
		if (frame5code.guntype == 0) {
			frame5text.text = "HEGrenade";
		}
		if (frame5code.guntype == 1) {
			frame5text.text = "Molotov";
		}
		//

	}



	

	/////Buy and Select
	public void buygun() {
		if (money >= priceholder) {
			if (selectedgun == "cz") {
				czlock.GetComponent<Image> ().enabled = false;
				czpurchased = true;
				money -= czprice;
				moneyui.text = "$" + money.ToString ();
				///
				PlayerPrefs.SetInt ("czpurchased", (czpurchased ? 1 : 0));

			}
			if (selectedgun == "auto") {
				autolock.GetComponent<Image> ().enabled = false;
				autopurchased = true;
				money -= autopistolprice;
				moneyui.text = "$" + money.ToString ();
				///
				PlayerPrefs.SetInt ("autopurchased", (autopurchased ? 1 : 0));
			}
			if (selectedgun == "revolver") {
				revolverlock.GetComponent<Image> ().enabled = false;
				revolverpurchased = true;
				money -= revolverprice;
				moneyui.text = "$" + money.ToString ();
				///
				PlayerPrefs.SetInt ("revolverpurchased", (revolverpurchased ? 1 : 0));
			}
			if (selectedgun == "mp5") {
				mp5lock.GetComponent<Image> ().enabled = false;
				mp5purchased = true;
				money -= mp5price;
				moneyui.text = "$" + money.ToString ();
				///
				PlayerPrefs.SetInt ("mp5purchased", (mp5purchased ? 1 : 0));
			}
			if (selectedgun == "spectre") {
				spectrelock.GetComponent<Image> ().enabled = false;
				spectrepurchased = true;
				money -= spectreprice;
				moneyui.text = "$" + money.ToString ();
				///
				PlayerPrefs.SetInt ("spectrepurchased", (spectrepurchased ? 1 : 0));
			}
			if (selectedgun == "ump") {
				umplock.GetComponent<Image> ().enabled = false;
				umppurchased = true;
				money -= umpprice;
				moneyui.text = "$" + money.ToString ();
				///
				PlayerPrefs.SetInt ("umppurchased", (umppurchased ? 1 : 0));
			}
			if (selectedgun == "p90") {
				p90lock.GetComponent<Image> ().enabled = false;
				p90purchased = true;
				money -= p90price;
				moneyui.text = "$" + money.ToString ();
				///
				PlayerPrefs.SetInt ("p90purchased", (p90purchased ? 1 : 0));
			}
			if (selectedgun == "gali") {
				galilock.GetComponent<Image> ().enabled = false;
				galipurchased = true;
				money -= galiprice;
				moneyui.text = "$" + money.ToString ();
				///
				PlayerPrefs.SetInt ("galipurchased", (galipurchased ? 1 : 0));
			}
			if (selectedgun == "famas") {
				famaslock.GetComponent<Image> ().enabled = false;
				famaspurchased = true;
				money -= famasprice;
				moneyui.text = "$" + money.ToString ();
				///
				PlayerPrefs.SetInt ("famaspurchased", (famaspurchased ? 1 : 0));
			}
			if (selectedgun == "sg") {
				sglock.GetComponent<Image> ().enabled = false;
				sgpurchased = true;
				money -= sgprice;
				moneyui.text = "$" + money.ToString ();
				///
				PlayerPrefs.SetInt ("sgpurchased", (sgpurchased ? 1 : 0));
			}
			if (selectedgun == "m4a1") {
				m4a1lock.GetComponent<Image> ().enabled = false;
				m4a1purchased = true;
				money -= m4a1price;
				moneyui.text = "$" + money.ToString ();
				///
				PlayerPrefs.SetInt ("m4a1purchased", (m4a1purchased ? 1 : 0));
			}
			if (selectedgun == "rocket") {
				rocketlock.GetComponent<Image> ().enabled = false;
				rocketpurchased = true;
				money -= rocketprice;
				moneyui.text = "$" + money.ToString ();
				///
				PlayerPrefs.SetInt ("rocketpurchased", (rocketpurchased ? 1 : 0));
			}
			if (selectedgun == "molotov") {
				molotovlock.GetComponent<Image> ().enabled = false;
				molotovpurchased = true;
				money -= molotovprice;
				moneyui.text = "$" + money.ToString ();
				///
				PlayerPrefs.SetInt ("molotovpurchased", (molotovpurchased ? 1 : 0));
			}
			if (selectedgun == "bigsniper") {
				bigsniperlock.GetComponent<Image> ().enabled = false;
				bigsniperpurchased = true;
				money -= bigsniperprice;
				moneyui.text = "$" + money.ToString ();
				infotext.SetActive (true);
				gunboxcode.bigsniperpurchased = true;
				///
				PlayerPrefs.SetInt ("bigsniperpurchased", (bigsniperpurchased ? 1 : 0));
			}
			if (selectedgun == "handturret") {
				handturretlock.GetComponent<Image> ().enabled = false;
				handturretpurchased = true;
				money -= handturretprice;
				moneyui.text = "$" + money.ToString ();
				infotext.SetActive (true);
				gunboxcode.handturretpurchased = true;
				///
				PlayerPrefs.SetInt ("handturretpurchased", (handturretpurchased ? 1 : 0));
			}
			if (selectedgun == "shotgun") {
				shotgunlock.GetComponent<Image> ().enabled = false;
				shotgunpurchased = true;
				money -= shotgunprice;
				moneyui.text = "$" + money.ToString ();
				infotext.SetActive (true);
				gunboxcode.shotgunpurchased = true;
				///
				PlayerPrefs.SetInt ("shotgunpurchased", (shotgunpurchased ? 1 : 0));
			}
			if (selectedgun == "antigrav") {
				antigravlock.GetComponent<Image> ().enabled = false;
				antigravpurchased = true;
				money -= antigravprice;
				moneyui.text = "$" + money.ToString ();
				infotext.SetActive (true);
				gunboxcode.antigravpurchased = true;
				///
				PlayerPrefs.SetInt ("antigravpurchased", (antigravpurchased ? 1 : 0));
			}
			PlayerPrefs.SetInt ("Money", money);

			if (selectedgun != "antigrav" && selectedgun != "shotgun" && selectedgun != "handturret" && selectedgun != "bigsniper") {
				equipbutton.SetActive (true);
			}
			upgradebutton.GetComponent<Image> ().enabled = false;
			price.GetComponent<Text> ().enabled = false;
		}
	}



	public void selectbaretta() {
		selectedgun = "baretta";
		turnonandoff ();
		thegunscode.guntype = 1;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + barettaprice.ToString ();
		priceholder = barettaprice;
		if (barettapurchased == true) {
			equipbutton.SetActive (true);
		}
		if (barettapurchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectcz() {
		selectedgun = "cz";
		turnonandoff ();
		thegunscode.guntype = 2;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + czprice.ToString ();
		priceholder = czprice;
		if (czpurchased == true) {
			equipbutton.SetActive (true);
		}
		if (czpurchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectautopistol() {
		selectedgun = "auto";
		turnonandoff ();
		thegunscode.guntype = 3;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + autopistolprice.ToString ();
		priceholder = autopistolprice;
		if (autopurchased == true) {
			equipbutton.SetActive (true);
		}
		if (autopurchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectrevolver() {
		selectedgun = "revolver";
		turnonandoff ();
		thegunscode.guntype = 4;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + revolverprice.ToString ();
		priceholder = revolverprice;
		if (revolverpurchased == true) {
			equipbutton.SetActive (true);
		}
		if (revolverpurchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectmac10() {
		selectedgun = "mac10";
		turnonandoff ();
		thegunscode.guntype = 5;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + mac10price.ToString ();
		priceholder = mac10price;
		if (mac10purchased == true) {
			equipbutton.SetActive (true);
		}
		if (mac10purchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectmp5() {
		selectedgun = "mp5";
		turnonandoff ();
		thegunscode.guntype = 6;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + mp5price.ToString ();
		priceholder = mp5price;
		if (mp5purchased == true) {
			equipbutton.SetActive (true);
		}
		if (mp5purchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectspectre() {
		selectedgun = "spectre";
		turnonandoff ();
		thegunscode.guntype = 7;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + spectreprice.ToString ();
		priceholder = spectreprice;
		if (spectrepurchased == true) {
			equipbutton.SetActive (true);
		}
		if (spectrepurchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectump() {
		selectedgun = "ump";
		turnonandoff ();
		thegunscode.guntype = 8;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + umpprice.ToString ();
		priceholder = umpprice;
		if (umppurchased == true) {
			equipbutton.SetActive (true);
		}
		if (umppurchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectp90() {
		selectedgun = "p90";
		turnonandoff ();
		thegunscode.guntype = 9;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + p90price.ToString ();
		priceholder = p90price;
		if (p90purchased == true) {
			equipbutton.SetActive (true);
		}
		if (p90purchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectxm8() {
		selectedgun = "xm8";
		turnonandoff ();
		thegunscode.guntype = 10;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + xm8price.ToString ();
		priceholder = xm8price;
		if (xm8purchased == true) {
			equipbutton.SetActive (true);
		}
		if (xm8purchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectgali() {
		selectedgun = "gali";
		turnonandoff ();
		thegunscode.guntype = 11;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + galiprice.ToString ();
		priceholder = galiprice;
		if (galipurchased == true) {
			equipbutton.SetActive (true);
		}
		if (galipurchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectfamas() {
		selectedgun = "famas";
		turnonandoff ();
		thegunscode.guntype = 12;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + famasprice.ToString ();
		priceholder = famasprice;
		if (famaspurchased == true) {
			equipbutton.SetActive (true);
		}
		if (famaspurchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectsg() {
		selectedgun = "sg";
		turnonandoff ();
		thegunscode.guntype = 13;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + sgprice.ToString ();
		priceholder = sgprice;
		if (sgpurchased == true) {
			equipbutton.SetActive (true);
		}
		if (sgpurchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectm4a1() {
		selectedgun = "m4a1";
		turnonandoff ();
		thegunscode.guntype = 14;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + m4a1price.ToString ();
		priceholder = m4a1price;
		if (m4a1purchased == true) {
			equipbutton.SetActive (true);
		}
		if (m4a1purchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectm32() {
		selectedgun = "m32";
		turnonandoff ();
		thegunscode.guntype = 15;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + m32price.ToString ();
		priceholder = m32price;
		if (m32purchased == true) {
			equipbutton.SetActive (true);
		}
		if (m32purchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectrocket() {
		selectedgun = "rocket";
		turnonandoff ();
		thegunscode.guntype = 16;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + rocketprice.ToString ();
		priceholder = rocketprice;
		if (rocketpurchased == true) {
			equipbutton.SetActive (true);
		}
		if (rocketpurchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selecthegrenade() {
		selectedgun = "hegrenade";
		turnonandoff ();
		thegunscode.guntype = 17;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + hegrenadeprice.ToString ();
		priceholder = hegrenadeprice;
		if (hegrenadepurchased == true) {
			equipbutton.SetActive (true);
		}
		if (hegrenadepurchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	public void selectmolotov() {
		selectedgun = "molotov";
		turnonandoff ();
		thegunscode.guntype = 18;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + molotovprice.ToString ();
		priceholder = molotovprice;
		if (molotovpurchased == true) {
			equipbutton.SetActive (true);
		}
		if (molotovpurchased == false) {
			equipbutton.SetActive (false);
		}
		equiptext.SetActive (true);
		infotext.SetActive (false);
	}
	///
	public void selectawp() {
		selectedgun = "awp";
		turnonandoff ();
		thegunscode.guntype = 19;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + awpprice.ToString ();
		priceholder = awpprice;
		if (awppurchased == true) {
			equipbutton.SetActive (false);
			infotext.SetActive (true);
		}
		if (awppurchased == false) {
			equipbutton.SetActive (false);
			infotext.SetActive (false);
		}
		equiptext.SetActive (false);

	}
	public void selectbigbessy() {
		selectedgun = "bigbessy";
		turnonandoff ();
		thegunscode.guntype = 20;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + bigbessyprice.ToString ();
		priceholder = bigbessyprice;
		if (bigbessypurchased == true) {
			equipbutton.SetActive (false);
			infotext.SetActive (true);
		}
		if (bigbessypurchased == false) {
			equipbutton.SetActive (false);
			infotext.SetActive (false);
		}
		equiptext.SetActive (false);

	}
	public void selectlaser() {
		selectedgun = "laser";
		turnonandoff ();
		thegunscode.guntype = 21;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + laserprice.ToString ();
		priceholder = laserprice;
		if (laserpurchased == true) {
			equipbutton.SetActive (false);
			infotext.SetActive (true);
		}
		if (laserpurchased == false) {
			equipbutton.SetActive (false);
			infotext.SetActive (false);
		}
		equiptext.SetActive (false);

	}
	public void selectbigsniper() {
		selectedgun = "bigsniper";
		turnonandoff ();
		thegunscode.guntype = 22;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + bigsniperprice.ToString ();
		priceholder = bigsniperprice;
		if (bigsniperpurchased == true) {
			equipbutton.SetActive (false);
			infotext.SetActive (true);
		}
		if (bigsniperpurchased == false) {
			equipbutton.SetActive (false);
			infotext.SetActive (false);
		}
		equiptext.SetActive (false);

	}
	public void selecthandturret() {
		selectedgun = "handturret";
		turnonandoff ();
		thegunscode.guntype = 23;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + handturretprice.ToString ();
		priceholder = handturretprice;
		if (handturretpurchased == true) {
			equipbutton.SetActive (false);
			infotext.SetActive (true);
		}
		if (handturretpurchased == false) {
			equipbutton.SetActive (false);
			infotext.SetActive (false);
		}
		equiptext.SetActive (false);

	}
	public void selectshotgun() {
		selectedgun = "shotgun";
		turnonandoff ();
		thegunscode.guntype = 24;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + shotgunprice.ToString ();
		priceholder = shotgunprice;
		if (shotgunpurchased == true) {
			equipbutton.SetActive (false);
			infotext.SetActive (true);
		}
		if (shotgunpurchased == false) {
			equipbutton.SetActive (false);
			infotext.SetActive (false);
		}
		equiptext.SetActive (false);

	}
	public void selectantigrav() {
		selectedgun = "antigrav";
		turnonandoff ();
		thegunscode.guntype = 25;
		thegunscode.switchweapons ();
		buypriceui.text = "$" + antigravprice.ToString ();
		priceholder = antigravprice;
	
		if (antigravpurchased == true) {
			equipbutton.SetActive (false);
			infotext.SetActive (true);
		}
		if (antigravpurchased == false) {
			equipbutton.SetActive (false);
			infotext.SetActive (false);
		}
		equiptext.SetActive (false);

	}
	//
	public void turnonandoff() {
		if (selectedgun == "baretta") {
			if (barettapurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (barettapurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}
		if (selectedgun == "cz") {
			if (czpurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (czpurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}
		if (selectedgun == "auto") {
			if (autopurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (autopurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}
		if (selectedgun == "revolver") {
			if (revolverpurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (revolverpurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}
		if (selectedgun == "mac10") {
			if (mac10purchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (mac10purchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "mp5") {
			if (mp5purchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (mp5purchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "spectre") {
			if (spectrepurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (spectrepurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "ump") {
			if (umppurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (umppurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "p90") {
			if (p90purchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (p90purchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "xm8") {
			if (xm8purchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (xm8purchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "gali") {
			if (galipurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (galipurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "famas") {
			if (famaspurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (famaspurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "sg") {
			if (sgpurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (sgpurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "m4a1") {
			if (m4a1purchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (m4a1purchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "m32") {
			if (m32purchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (m32purchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "rocket") {
			if (rocketpurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (rocketpurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "hegrenade") {
			if (hegrenadepurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (hegrenadepurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "molotov") {
			if (molotovpurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (molotovpurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "awp") {
			if (awppurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (awppurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "bigbessy") {
			if (bigbessypurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (bigbessypurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "laser") {
			if (laserpurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (laserpurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "bigsniper") {
			if (bigsniperpurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (bigsniperpurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "handturret") {
			if (handturretpurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (handturretpurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "shotgun") {
			if (shotgunpurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (shotgunpurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
		if (selectedgun == "antigrav") {
			if (antigravpurchased == true) {
				upgradebutton.GetComponent<Image> ().enabled = false;
				price.GetComponent<Text> ().enabled = false;
			}
			if (antigravpurchased == false) {
				upgradebutton.GetComponent<Image> ().enabled = true;
				price.GetComponent<Text> ().enabled = true;
			}
		}	
	}
		



	public void equipprimary() {

		beep.Play ();
		if (selectedgun == "baretta") {
			frame1code.guntype = 1;
			frame1code.switchweaponssprites ();
			frame1text.text = "Beretta";
			gunframecode.framegun = 1; 
		}
		if (selectedgun == "cz" && czpurchased == true) {
			frame1code.guntype = 2;
			frame1code.switchweaponssprites ();
			frame1text.text = "CZ-75";
			gunframecode.framegun = 2; 
		}
		if (selectedgun == "auto" && autopurchased == true) {
			frame1code.guntype = 3;
			frame1code.switchweaponssprites ();
			frame1text.text = "Auto Pistol";
			gunframecode.framegun = 3; 
		}
		if (selectedgun == "revolver" && revolverpurchased == true) {
			frame1code.guntype = 4;
			frame1code.switchweaponssprites ();
			frame1text.text = "Revolver";
			gunframecode.framegun = 4; 
		}
		//
		if (selectedgun == "mac10") {
			frame2code.guntype = 0;
			frame2code.switchweaponssprites ();
			frame2text.text = "Mac-10";
			gunframe2code.framegun = 5; 
		}
		if (selectedgun == "mp5") {
			frame2code.guntype = 1;
			frame2code.switchweaponssprites ();
			frame2text.text = "MP5";
			gunframe2code.framegun = 6; 
		}
		if (selectedgun == "spectre") {
			frame2code.guntype = 2;
			frame2code.switchweaponssprites ();
			frame2text.text = "Spectre";
			gunframe2code.framegun = 7; 
		}
		if (selectedgun == "ump") {
			frame2code.guntype = 3;
			frame2code.switchweaponssprites ();
			frame2text.text = "UMP";
			gunframe2code.framegun = 8; 
		}
		if (selectedgun == "p90") {
			frame2code.guntype = 4;
			frame2code.switchweaponssprites ();
			frame2text.text = "P90";
			gunframe2code.framegun = 9; 
		}
		///
		if (selectedgun == "xm8") {
			frame3code.guntype = 0;
			frame3code.switchweaponssprites ();
			frame3text.text = "XM-8";
			gunframe3code.framegun = 10; 
		}
		if (selectedgun == "gali") {
			frame3code.guntype = 1;
			frame3code.switchweaponssprites ();
			frame3text.text = "Gali";
			gunframe3code.framegun = 11;
		}
		if (selectedgun == "famas") {
			frame3code.guntype = 2;
			frame3code.switchweaponssprites ();
			frame3text.text = "Famas";
			gunframe3code.framegun = 12;
		}
		if (selectedgun == "sg") {
			frame3code.guntype = 3;
			frame3code.switchweaponssprites ();
			frame3text.text = "Sg";
			gunframe3code.framegun = 13; 
		}
		if (selectedgun == "m4a1") {
			frame3code.guntype = 4;
			frame3code.switchweaponssprites ();
			frame3text.text = "M4A1";
			gunframe3code.framegun = 14; 
		}
		///
		if (selectedgun == "m32") {
			frame4code.guntype = 0;
			frame4code.switchweaponssprites ();
			frame4text.text = "M32";
			gunframe4code.framegun = 15; 
		}
		if (selectedgun == "rocket") {
			frame4code.guntype = 1;
			frame4code.switchweaponssprites ();
			frame4text.text = "Rocket";
			gunframe4code.framegun = 16; 
		}
		//
		if (selectedgun == "hegrenade") {
			frame5code.guntype = 0;
			frame5code.switchweaponssprites ();
			frame5text.text = "hegrenade";
			gunframe5code.framegun = 17; 
		}
		if (selectedgun == "molotov") {
			frame5code.guntype = 1;
			frame5code.switchweaponssprites ();
			frame5text.text = "molotov";
			gunframe5code.framegun = 18; 
		}

		PlayerPrefs.SetInt ("frame1guntype", frame1code.guntype);
		PlayerPrefs.SetInt ("frame2guntype", frame2code.guntype);
		PlayerPrefs.SetInt ("frame3guntype", frame3code.guntype);
		PlayerPrefs.SetInt ("frame4guntype", frame4code.guntype);
		PlayerPrefs.SetInt ("frame5guntype", frame5code.guntype);
		PlayerPrefs.SetInt ("gunframecode", gunframecode.framegun);
		PlayerPrefs.SetInt ("gunframe2code", gunframe2code.framegun);
		PlayerPrefs.SetInt ("gunframe3code", gunframe3code.framegun);
		PlayerPrefs.SetInt ("gunframe4code", gunframe4code.framegun);
		PlayerPrefs.SetInt ("gunframe5code", gunframe5code.framegun);
	}
		


	public void beginlevel() {

		Time.timeScale = 1;
		AudioListener.pause = false;


		beep.Play ();
		uihud.SetActive (true);
		hudsgrenade.SetActive (false);
		shootingcode.resetammo ();
		pagesoff ();
		isvisible = false;
		theshop.GetComponent<Canvas> ().enabled = false;
		maincode.startgame ();
		resetdoors ();
		ReviveOMatic.SetActive (true);
		playercode.showshoponce = false;
		fadingcode.hideblack ();
		maincode.enemieskilled = 0;
		maincode.headshots = 0;
		maincode.wavessurvived = 0;
		maincode.missionscomplete = 0;
		maincode.randomchatter ();
		maincode.zombiespawnamountholder = 50;
		maincode.zombieshealthholder = 16;
		///
		shootingcode.grenadeamount = 0;
		shootingcode.primary = 0;
		shootingcode.secondary = 0;
		shootingcode.GunUISpritescode.guntype = 0;
		shootingcode.GunUISpritescode.switchweapons ();
		shootingcode.GunUISpritescode2.guntype = 0;
		shootingcode.GunUISpritescode2.switchweapons ();
		shootingcode.switchtheguntype ();
		shootingcode.resetammo ();
		shootingcode.ammoleftholder2 = 999999;
		playercode.imdying = false;
		//

	}

	public void showshop() {
		
		chatbox.SetActive (false);
		maincode.hidethemissions ();
		uihud.SetActive (false);
		isvisible = true;
		theshop.GetComponent<Canvas> ().enabled = true;
		Equippage.SetActive (true);
	}


	public void pressequip() {
		pagesoff ();
		Equippage.SetActive (true);
		//beep.Play ();
		//
		if (gunframecode.framegun == 1) {
			pistolsequippedui.guntype = 0;
			pistolsequippedui.switchweapons ();
			pistolstextui.text = "Beretta";
		}
		if (gunframecode.framegun == 2) {
			pistolsequippedui.guntype = 1;
			pistolsequippedui.switchweapons ();
			pistolstextui.text = "CZ75";
		}
		if (gunframecode.framegun == 3) {
			pistolsequippedui.guntype = 2;
			pistolsequippedui.switchweapons ();
			pistolstextui.text = "Auto Pistol";
		}
		if (gunframecode.framegun == 4) {
			pistolsequippedui.guntype = 3;
			pistolsequippedui.switchweapons ();
			pistolstextui.text = "Revolver";
		}
		//2nd
		if (gunframe2code.framegun == 5) {
			smgsequippedui.guntype = 0;
			smgsequippedui.switchweapons ();
			smgstextui.text = "Mac-10";
		}
		if (gunframe2code.framegun == 6) {
			smgsequippedui.guntype = 1;
			smgsequippedui.switchweapons ();
			smgstextui.text = "MP5";
		}
		if (gunframe2code.framegun == 7) {
			smgsequippedui.guntype = 2;
			smgsequippedui.switchweapons ();
			smgstextui.text = "Spectre";
		}
		if (gunframe2code.framegun == 8) {
			smgsequippedui.guntype = 3;
			smgsequippedui.switchweapons ();
			smgstextui.text = "UMP";
		}
		if (gunframe2code.framegun == 9) {
			smgsequippedui.guntype = 4;
			smgsequippedui.switchweapons ();
			smgstextui.text = "P90";
		}
		///3rd
		if (gunframe3code.framegun == 10) {
			riflesequippedui.guntype = 0;
			riflesequippedui.switchweapons ();
			riflestextui.text = "XM-8";
		}
		if (gunframe3code.framegun == 11) {
			riflesequippedui.guntype = 1;
			riflesequippedui.switchweapons ();
			riflestextui.text = "Gali";
		}
		if (gunframe3code.framegun == 12) {
			riflesequippedui.guntype = 2;
			riflesequippedui.switchweapons ();
			riflestextui.text = "Famas";
		}
		if (gunframe3code.framegun == 13) {
			riflesequippedui.guntype = 3;
			riflesequippedui.switchweapons ();
			riflestextui.text = "Sg";
		}
		if (gunframe3code.framegun == 14) {
			riflesequippedui.guntype = 4;
			riflesequippedui.switchweapons ();
			riflestextui.text = "M4A1";
		}
		//4th
		if (gunframe4code.framegun == 15) {
			heavyequippedui.guntype = 0;
			heavyequippedui.switchweapons ();
			heavytextui.text = "M32";
		}
		if (gunframe4code.framegun == 16) {
			heavyequippedui.guntype = 1;
			heavyequippedui.switchweapons ();
			heavytextui.text = "Rocket";
		}
		//5th
		if (gunframe5code.framegun == 17) {
			grenadesequippedui.guntype = 0;
			grenadesequippedui.switchweapons ();
			grenadestextui.text = "HE Grenade";
		}
		if (gunframe5code.framegun == 18) {
			grenadesequippedui.guntype = 1;
			grenadesequippedui.switchweapons ();
			grenadestextui.text = "Molotov";
		}

	}
	public void presspistols() {
		pagesoff ();
		buysidebar.SetActive (true);
		pistolspage.SetActive (true);
		beep.Play ();
	}
	public void pressSMG() {
		pagesoff ();
		buysidebar.SetActive (true);
		smgpage.SetActive (true);
		beep.Play ();
	}
	public void pressrifle() {
		pagesoff ();
		buysidebar.SetActive (true);
		riflepage.SetActive (true);
		beep.Play ();
	}
	public void pressheavy() {
		pagesoff ();
		buysidebar.SetActive (true);
		heavypage.SetActive (true);
		beep.Play ();
	}
	public void pressgrenades() {
		pagesoff ();
		buysidebar.SetActive (true);
		grenadespage.SetActive (true);
		beep.Play ();
	}
	public void pressbox() {
		pagesoff ();
		buysidebar.SetActive (true);
		boxpage.SetActive (true);
		beep.Play ();
	}

	///////Unchangeables///
	///////////////////////
	///////////////////////
	///////Switch Pages
	void pagesoff() {
		Equippage.SetActive (false);
		buysidebar.SetActive (false);
		pistolspage.SetActive (false);
		smgpage.SetActive (false);
		riflepage.SetActive (false);
		heavypage.SetActive (false);
		grenadespage.SetActive (false);
		boxpage.SetActive (false);
	}
	void pageson() {
		Equippage.SetActive (true);
		buysidebar.SetActive (true);
		pistolspage.SetActive (true);
		smgpage.SetActive (true);
		riflepage.SetActive (true);
		heavypage.SetActive (true);
		grenadespage.SetActive (true);
		boxpage.SetActive (true);
	}

	void resetdoors() {
		door1.SetActive (true);
		door2.SetActive (true);
		door3.SetActive (true);
		door4.SetActive (true);
		door5.SetActive (true);
		door6.SetActive (true);
		door7.SetActive (true);
		overlaytext1.GetComponent<Text> ().enabled = true;
		overlaytext2.GetComponent<Text> ().enabled = true;
		overlaytext3.GetComponent<Text> ().enabled = true;
		overlaytext4.GetComponent<Text> ().enabled = true;
		overlaytext5.GetComponent<Text> ().enabled = true;
		overlaytext6.GetComponent<Text> ().enabled = true;
		overlaytext7.GetComponent<Text> ().enabled = true;
	}
}
