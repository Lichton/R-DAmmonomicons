using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Alexandria;
using Alexandria.ItemAPI;
using BepInEx;
using Dungeonator;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace ETGClasses
{

    public static class GameStart
    {

		public static void Init()
		{
			//West
			MakeEntry(
			"Western Bullet Kin",
			"5861e5a077244905a8c25c2b7b4d6ebb",
			"BULLET_KIN_COWBOY",
			"bullet_kin_cowboy",
			"RNDAmmonomicons/Resources/Buttons/bullet_west_idle_front_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\bullet_west_ammonomicon.png",
			false,
			true,
			43,
			"High Noon Shootdown",
			"The bullet kin of the west come in many shapes and sizes. \n\nThough some may be found driving cattle and others digging for gold, all of them are alike in that which matters most: each is eager for a scenic gunfight when Gunymede's sun is at its peak."
			);
			MakeEntry(
			"Western Shotgun Kin",
			"ddf12a4881eb43cfba04f36dd6377abb",
			"COWBOY_SHOTGUN_KIN",
			"cowboy_shotgun_kin",
			"RNDAmmonomicons/Resources/Buttons/shotgun_west_idle_front_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\shotgun_west_ammonomicon.png",
			false,
			true,
			43,
			"Caballeret",
			"This shotgun kin proudly wears the traditional garb of his land, and maintains a mustache that is the envy of all bulletkin except for the Minelets themselves. \n\nThat matters little to them, however, as their purpose was never to impress."
			);
			MakeEntry(
			"Cactus Kin",
			"3b0bd258b4c9432db3339665cc61c356",
			"CACTUS_KIN",
			"cactus_kin",
			"RNDAmmonomicons/Resources/Buttons/cactus_idle_front_001",
			"RNDAmmonomicons\\Resources\\Pictures\\cactus_ammonomicon.png",
			false,
			true,
			43,
			"Looking Sharp!",
			"The strange powers of the Gungeon have deemed some of the largest of the gun cacti to be worthy of becoming akin to the Gundead. \n\nSome appear to have taken their new existence to be more akin to a curse than a blessing, however, and are eager to make their distaste be known."
			);
			MakeEntry(
			"Snake",
			"e861e59012954ab2b9b6977da85cb83c",
			"SNAKE",
			"snake",
			"RNDAmmonomicons/Resources/Buttons/snake_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\snake_ammonomicon.png",
			false,
			true,
			43,
			"Solid Serpent",
			"Perhaps one of the least remarkable denizens of the Gungeon, the Snakes have nonetheless learned to channel their inherent gunning potential to shoot a spread of bullets from their mouth. \n\nThough considered a pest by some, they are an important part of the Gungeon ecosystem. Commonly found hiding inside boots."
			);
			//Pirate
			MakeEntry(
			"Pirate Bullet Kin",
			"6f818f482a5c47fd8f38cce101f6566c",
			"BULLET_KIN_PIRATE",
			"bullet_kin_pirate",
			"RNDAmmonomicons/Resources/Buttons/pirate_bullet_idle_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\pirate_bullet_ammonomicon.png",
			false,
			true,
			43,
			"Barreltt's Privateers",
			"These hardened pirates and privateers have truly taken their roles to heart. \n\nEagerly wearing anything that might enhance their swashbuckling appearance, they have yet to realize that blocking both their eyes with eyepatches is usually not a wise choice for a gunfight."
			);
			MakeEntry(
			"Pirate Shotgun Kin",
			"86dfc13486ee4f559189de53cfb84107",
			"PIRATE_SHOTGUN_KIN",
			"pirate_shotgun_kin",
			"RNDAmmonomicons/Resources/Buttons/pirate_shotgunguy_idle_front_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\pirate_shotgunguy_ammonomicon.png",
			false,
			true,
			43,
			"On Which The Gun Never Sets",
			"A high-ranking member of the admiralty tasked with putting a stop to independent privateers, although many of them would disappear in a fateful event that has for long been shrouded in mystery."
			);
			MakeEntry(
			"Musket Kin",
			"226fd90be3a64958a5b13cb0a4f43e97",
			"MUSKET_KIN",
			"musket_kin",
			"RNDAmmonomicons/Resources/Buttons/musketball_guy_idle_front_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\musketball_guy_ammonomicon.png",
			false,
			true,
			43,
			"Pike & Shot",
			"The relation between the Musketballs and the Cannonbalrog have for long been a subject of debate between gungeoneering scholars. \n\nMany believe the Musketballs to be the spawn of the Cannonbalrog, while some say they are closely related species. \n\nSome madmen even argue that the Cannonbalrog is the unholy union between a Musketball and a Skusket."
			);
			MakeEntry(
			"Parrot",
			"4b21a913e8c54056bc05cafecf9da880",
			"PARROT",
			"parrot",
			"RNDAmmonomicons/Resources/Buttons/parrot_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\parrot_ammonomicon.png",
			false,
			true,
			43,
			"Birds Of A Weathered",
			"No one is certain whether the Parrot was a native species to Gunymede or if it was introduced to the planet at some point in its history. \n\nRegardless of its origins, the Parrots thrive in some chambers of the Gungeon, and have largely learned to mimic the Gigis' behaviour. A favoured companion to Pirate Bullet Kin."
			);
			MakeEntry(
			"Office Bullet Kin",
			"9eba44a0ea6c4ea386ff02286dd0e6bd",
			"BULLET_KIN_OFFICESUIT",
			"bullet_kin_officesuit",
			"RNDAmmonomicons/Resources/Buttons/office_bullet_idle_front_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\office_bullet_ammonomicon.png",
			false,
			true,
			43,
			"Hard Worksmanship",
			"These Bullet Kin have found themselves in what might be one of the least remarkable positions in Gundead society. \n\nToiling away for hours upon hours in their tiny cubicles, they spend their days daydreaming of the moment when a Gungeoneer finally reaches their department so that, in a blaze of glory and destruction, they will finally be given the experience that all Gundead desire most."
			);
			MakeEntry(
			"Fridge Maiden",
			"9215d1a221904c7386b481a171e52859",
			"FRIDGE_MAIDEN",
			"fridge_maiden",
			"RNDAmmonomicons/Resources/Buttons/fridge_maiden_idle_001",
			"RNDAmmonomicons\\Resources\\Pictures\\fridge_maiden_ammonomicon.png",
			false,
			true,
			89,
			"Niece Of The Freeze",
			"Although it might not seem like it at first glance, the gundead pride themselves in their ability to reuse much that would otherwise go to waste. \n\nIt should not surprise one, then, to learn what became of these broken or misplaced iron maidens after an office bullet kin first decided to store cheese in them. Then, the Flaktory caught wind of this development and... innovated."
			);
			MakeEntry(
			"Bullat Gargoyle",
			"981d358ffc69419bac918ca1bdf0c7f7",
			"BULLAT_GARGOYLE",
			"bullat_gargoyle",
			"RNDAmmonomicons/Resources/Buttons/gargoyle_bullet_south_idle_001",
			"RNDAmmonomicons\\Resources\\Pictures\\Bullat_Gargoyle_ammonomicon.png",
			false,
			true,
			85,
			"Guntesque",
			"Originally made to serve as a simple decorative water spout, the Bullet Gargoyle's tendency to spontaneously burst to life quickly shifted its use into being a protector of the gundead. \n\nHas the additional benefit of being more easily made back into a decorative statue than most other living guardians."
			);
			MakeEntry(
			"Bullet Titan",
			"c4cf0620f71c4678bb8d77929fd4feff",
			"BULLET_KIN_TITAN",
			"bullet_kin_titan",
			"RNDAmmonomicons/Resources/Buttons/bullettitan_idle_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\bullet_titan_ammonomicon.png",
			false,
			true,
			85,
			"Attacking Titan",
			"These Bullet Kin have been forged with a rare condition that causes them to grow to enormous proportions during their lives. \n\nAlthough their admirable size comes with a comparably huge set of problems, they are ultimately proud of their high position in their society, and stand tall before any challenges that may arise."
			);
			MakeEntry(
			"Boss Bullet Titan",
			"df4e9fedb8764b5a876517431ca67b86",
			"BULLET_KIN__GAL_TITAN_BOSS",
			"bullet_kin_gal_titan_boss",
			"RNDAmmonomicons/Resources/Buttons/bullet_titaness_idle_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\bullet_titan_boss_ammonomicon.png",
			false,
			true,
			85,
			"You're Fired!",
			"Among the Bullet Titans, a few distinguish themselves by their intelligence and resourcefulness, and quickly climb the ranks of the renowned R&G department to be the top brass. \n\nAlthough their inability to fit through doors makes it difficult for them to direct their underlings, the threat of being fired (usually through a very large gun) is often enough to keep their workers attemptive to their duties."
			);

			MakeEntry(
			"Necronomicon Bookllet",
			"216fd3dfb9da439d9bd7ba53e1c76462",
			"NECRONOMICON_BOOKLLET",
			"necronomicon_bookllet",
			"RNDAmmonomicons/Resources/Buttons/angry_necronomicon_attack_001",
			"RNDAmmonomicons\\Resources\\Pictures\\angry_necronomicon_ammonomicon.png",
			false,
			true,
			48,
			"Klaatu Beretta Nikto",
			"Once the Ammonomicon of a fallen Gungeoneer, this tone has been inked in gun grease and rebound in Gundead flesh."
			);
			MakeEntry(
			"Tablet Bookllet",
			"78e0951b097b46d89356f004dda27c42",
			"TABLET_BOOKLLET",
			"tablet_bookllet",
			"RNDAmmonomicons/Resources/Buttons/angry_tablet_attack_002",
			"RNDAmmonomicons\\Resources\\Pictures\\angry_tablet_ammonomicon.png",
			false,
			true,
			48,
			"The 10 Gunmandments",
			"An ancient stone tablet bearing inscriptions in a long-forgotten language. A strange and unyielding power resides somewhere therein."
			);
			MakeEntry(
			"Bullet Mech",
			"2b6854c0849b4b8fb98eb15519d7db1c",
			"BULLET_KIN_MECH",
			"bullet_kin_mech",
			"RNDAmmonomicons/Resources/Buttons/bullet_mech_idle_front_001",
			"RNDAmmonomicons\\Resources\\Pictures\\bullet_mech_ammonomicon.png",
			false,
			true,
			85,
			"Mobile Suit Gun, Damn!",
			"An experimental design that was very quickly put into production due to its 'remarkable bulletness'. \n\nOnly a small number of them were ever produced by the Flaktory before the R&G Department requested the equipment to instead be used for the manufacture of highly marketable Bullet Kin figurines."
			);
			MakeEntry(
			"Fish Kin",
			"143be8c9bbb84e3fb3ab98bcd4cf5e5b",
			"BULLET_KIN_FISH",
			"bullet_kin_fish",
			"RNDAmmonomicons/Resources/Buttons/bullet_fish_idle_front_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\bullet_fish_ammonomicon.png",
			false,
			true,
			43,
			"Out Of Water",
			"These slippery bullet kin have become adapted to a life underwater, yet retain the ability to survive on land. \n\nPreferring moist and fetid environments, their eggs are considered a delicacy by older Gungeoneers."
			);
			MakeEntry(
			"Brollet",
			"05cb719e0178478685dc610f8b3e8bfc",
			"BULLET_KIN_VEST",
			"bullet_kin_vest",
			"RNDAmmonomicons/Resources/Buttons/brollet_idle_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\BrolletMan_ammonomicon.png",
			false,
			true,
			43,
			"Short Fuse",
			"These fanatical Bullet Kin have sworn to live and die in Kaliber's honour, albeit few have seriously considered the latter part. \n\nLoaded with explosives so as to be able to kill even in death, other Bullet Kin are advised to tread lightly around them, avoid surprising them, and overall to mind their explosive temperament."
			);
			MakeEntry(
			"Firecracker",
			"5f15093e6f684f4fb09d3e7e697216b4",
			"NITRA_FIRECRACKER",
			"nitra_firecracker",
			"RNDAmmonomicons/Resources/Buttons/m80_guy_idle_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\m80_guy_ammonomicon.png",
			false,
			true,
			43,
			"Gunese New Year",
			"These powerful military-grade firecrackers have been banned from many Gundead parties due to their tendency to bring them to an explosive conclusion. \n\nSome places, however, have still not gotten the memo."
			);
			MakeEntry(
			"Candle Kin",
			"37de0df92697431baa47894a075ba7e9",
			"BULLET_KIN_CANDLE",
			"bullet_kin_candle",
			"RNDAmmonomicons/Resources/Buttons/candle_guy_idle_001",
			"RNDAmmonomicons\\Resources\\Pictures\\candle_guy_ammonomicon.png",
			false,
			true,
			43,
			"Something Wicked",
			"These strange, animated candles hold a stark resemblance to the Bullet Kin, leading many to theorize as to their origin. \n\nAre they but creatures of wax molded to the Gundead's resemblance, or the result of some foul ritual that have marked the end of what was once a Bullet Kin? Their purpose is but a still greater mystery, though few are foolish enough to interrupt the strange ceremonies wherein these beings are found gathered. "
			);
			MakeEntry(
			"Kalibullet",
			"ff4f54ce606e4604bf8d467c1279be3e",
			"BULLET_KIN_BROCCOLI",
			"bullet_kin_broccoli",
			"RNDAmmonomicons/Resources/Buttons/kalibullet_idle_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\Kalibullet_ammonomicon.png",
			false,
			true,
			43,
			"From The Depths",
			"An unearthly creature of unknown origin and a purpose that is still less familiar, these beings have long terrified the less experienced of Gungeoneers. \n\nTheir strange eye remain a thing of nightmares in the minds of even the most adept, standing as though a reminder of an even greater horror somewhere down below."
			);
			MakeEntry(
			"K Bullet",
			"f020570a42164e2699dcf57cac8a495c",
			"BULLET_KIN_KALIBER",
			"bullet_kin_kaliber",
			"RNDAmmonomicons/Resources/Buttons/kbullet_idle_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\kbullet_ammonomicon.png",
			false,
			true,
			43,
			"Treasurer Of The Night",
			"Divested from their souls and minds, these gunholy abominations shamble through the most esoteric of chambers, as though bathing in the memory of what they have long lost. \n\nFew dare to wager a guess as to what animates them and maintains their anti-natural existence; yet, amidst their inhuman growls, some claim to have heard naught but the very utterances of Her terrible name..."
			);
			MakeEntry(
			"Knight Kin",
			"39e6f47a16ab4c86bec4b12984aece4c",
			"BULLET_KIN_KNIGHT",
			"bullet_kin_knight",
			"RNDAmmonomicons/Resources/Buttons/bullet_armor_idle_left_001",
			"RNDAmmonomicons\\Resources\\Pictures\\bullet_armor_posessed_ammonomicon.png",
			false,
			true,
			43,
			"Knights of the Round Table",
			"These noble gundead have sworn fealty to the knightly code of conduct, and remain true to their honour even under the mockery of more modern bullet kin. \n\nSome still wander through the Gungeon in search of the mythical castle of Gunsalvaesche, from which the Holey Grail is said to have originated."
			);

			//Agunim
			MakeEntry(
			"Agunim",
			"41ee1c8538e8474a82a74c4aff99c712",
			"AGUNIM_HELICOPTER",
			"agunim_helicopter",
			"RNDAmmonomicons/Resources/Buttons/boss_icon_helicopter_agunim_001",
			"RNDAmmonomicons\\Resources\\Pictures\\boss_photo_helicopter_agunim_001.png",
			true,
			false,
			43,
			"You're Not Gunning Any Farther",
			"Following the woeful defeat of his master, the vizier would be banished to the R&G Department, from whence he'd tirelessly plot his part in the triumphant return of the mighty Cannon.\n\nYet, stripped of much of his power, he had to prepare himself for a duel with a gungeoneer, with whose blood he schemed to resurrect his slain master. Under the guise of a harmless sewer creature, he would buy the guns and items of unsuspecting gungeoneers, using them as parts for a hellish machine whose schematics he had found in his would-be prison. \n\nNow, he only needs a gungeoneer to prove himself worthy enough to be used as a sacrifice, and also foolish enough to follow the vizier into his begrudging lair."
			);
		}

        public static void MakeEntry(string EnemyName, string guid, string EnemyNameCode, string spawnName, string inTabSprite, string FullArtSprite, bool IsInBossTab, bool IsNormalEnemy, int ForcedPositionInAmmonomicon, string smallDescription, string BigDescription)
        {
			AIActor EnemyToAddDescription = EnemyDatabase.GetOrLoadByGuid(guid);
			SpriteBuilder.AddSpriteToCollection(inTabSprite, SpriteBuilder.ammonomiconCollection);
			if (EnemyToAddDescription.GetComponent<EncounterTrackable>() != null)
			{
				UnityEngine.Object.Destroy(EnemyToAddDescription.GetComponent<EncounterTrackable>());
			}
			EnemyToAddDescription.encounterTrackable = EnemyToAddDescription.gameObject.AddComponent<EncounterTrackable>();
			EnemyToAddDescription.encounterTrackable.journalData = new JournalEntry();
			EnemyToAddDescription.encounterTrackable.EncounterGuid = spawnName;
			EnemyToAddDescription.encounterTrackable.prerequisites = new DungeonPrerequisite[0];
			EnemyToAddDescription.encounterTrackable.journalData.SuppressKnownState = false;
			EnemyToAddDescription.encounterTrackable.journalData.IsEnemy = true;
			EnemyToAddDescription.encounterTrackable.journalData.SuppressInAmmonomicon = false;
			EnemyToAddDescription.encounterTrackable.ProxyEncounterGuid = "";
			EnemyToAddDescription.encounterTrackable.journalData.AmmonomiconSprite = inTabSprite;
			EnemyToAddDescription.encounterTrackable.journalData.enemyPortraitSprite = Alexandria.ItemAPI.ResourceExtractor.GetTextureFromResource(FullArtSprite);
			Module.Strings.Enemies.Set("#THE_" + EnemyNameCode, EnemyName);
			Module.Strings.Enemies.Set("#THE_"+ EnemyNameCode+"_SHORTDESC", smallDescription);
			Module.Strings.Enemies.Set("#THE_"+EnemyNameCode+"_LONGDESC", BigDescription);
			EnemyToAddDescription.encounterTrackable.journalData.PrimaryDisplayName = "#THE_" + EnemyNameCode;
			EnemyToAddDescription.encounterTrackable.journalData.NotificationPanelDescription = "#THE_" + EnemyNameCode + "_SHORTDESC";
			EnemyToAddDescription.encounterTrackable.journalData.AmmonomiconFullEntry = "#THE_"+EnemyNameCode+"_LONGDESC";
			EnemyBuilder.AddEnemyToDatabase(EnemyToAddDescription.gameObject, spawnName);
			EnemyDatabase.GetEntry(spawnName).ForcedPositionInAmmonomicon = ForcedPositionInAmmonomicon;
			EnemyDatabase.GetEntry(spawnName).isInBossTab = IsInBossTab;
			EnemyDatabase.GetEntry(spawnName).isNormalEnemy = IsNormalEnemy;
		}
    }
}