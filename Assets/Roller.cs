using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Roller : MonoBehaviour {

	public Toggle bonusDieEnabled;
	public Toggle tomesEnabled;

	public column bar0;
	public column bar1;
	public column bar2;
	public column bar3;
	public column bar4;
	public column bar5;
	public column bar6;
	public column bar7;

	int total0 = 0;
	int total1 = 0;
	int total2 = 0;
	int total3 = 0;
	int total4 = 0;
	int total5 = 0;
	int total6 = 0;
	int total7 = 0;

	const float GRIM_CHANCE = 1f;
	const float TOME_CHANCE = 0.66f;
	const float BONUS_CHANCE = 0.5f;
	const float SHIT_CHANCE = 0.33f;

	public void RollOne(){
		Roll (1);
	}

	public void RollTwo(){
		Roll (2);
	}

	public void RollZero(){
		Roll (0);
	}

	void Roll(int grim){
		bar0.SetValue (0, 0f);
		bar1.SetValue (0, 0f);
		total0 = 0;
		total1 = 0;
		total2 = 0;
		total3 = 0;
		total4 = 0;
		total5 = 0;
		total6 = 0;
		total7 = 0;

		StopAllCoroutines ();
		const int DIE = 7;
		int bonus = bonusDieEnabled.isOn ? 2 : 0;
		int tomes = tomesEnabled.isOn ? 3 : 0;
		int shit = DIE - bonus - tomes - grim;
		StartCoroutine(RollUpdate(grim, tomes, bonus, shit));
	}

	int Total(){
		return total0 + total1 + total2 + total3 + total4 + total5 + total6 + total7;
	}

	float Percent(float numerator) {
		return numerator / (float)Total ();
	}

	IEnumerator RollUpdate(int grim, int tome, int bonus, int shit){
		int rolls = 0;
		const int rollsPerFrame = 100;
		const int rollsTarget = 100000;//100,000

		while (rolls < rollsTarget) {
			int headsUp = grim;
			for(int i = 0; i <  rollsPerFrame;i++){
				//Roll Tomes
				for(int t = 0; t < tome;t++){
					if(Random.value <= TOME_CHANCE){
						headsUp++;
					}
				}
				//Roll Bonus Die
				for(int b = 0; b < bonus;b++){
					if(Random.value <= BONUS_CHANCE){
						headsUp++;
					}
				}
				//Roll Shit Die
				for(int s = 0; s < shit;s++){
					if(Random.value <= SHIT_CHANCE){
						headsUp++;
					}
				}

				switch (headsUp) {
					case 0:
						total0++;
						bar0.SetValue(total0, Percent(total0));
						break;
					case 1:
						total1++;
						bar1.SetValue(total1, Percent(total1));
						break;
					case 2:
						total2++;
						bar2.SetValue(total2, Percent(total2));
						break;
					case 3:
						total3++;
						bar3.SetValue(total3, Percent(total3));
						break;
					case 4:
						total4++;
						bar4.SetValue(total4, Percent(total4));
						break;
					case 5:
						total5++;
						bar5.SetValue(total5, Percent(total5));
						break;
					case 6:
						total6++;
						bar6.SetValue(total6, Percent(total6));
						break;
					case 7:
						total7++;
						bar7.SetValue(total7, Percent(total7));
						break;
					default: Debug.LogError("rolled imposi-die " + headsUp);
						break;
				}
				headsUp = grim;
				rolls++;
			}//end rollsPerFrame For
			yield return null;
		}
	}

}
