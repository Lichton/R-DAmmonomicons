using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ETGClasses
{
	public class AdvancedStringDB
	{
		public StringTableManager.GungeonSupportedLanguages CurrentLanguage
		{
			get
			{
				return GameManager.Options.CurrentLanguage;
			}
			set
			{
				StringTableManager.SetNewLanguage(value, true);
			}
		}

		public AdvancedStringDB()
		{
			StringDB strings = ETGMod.Databases.Strings;
			strings.OnLanguageChanged = (Action<StringTableManager.GungeonSupportedLanguages>)Delegate.Combine(strings.OnLanguageChanged, new Action<StringTableManager.GungeonSupportedLanguages>(this.LanguageChanged));
			this.Core = new AdvancedStringDBTable(() => StringTableManager.CoreTable);
			this.Items = new AdvancedStringDBTable(() => StringTableManager.ItemTable);
			this.Enemies = new AdvancedStringDBTable(() => StringTableManager.EnemyTable);
			this.Intro = new AdvancedStringDBTable(() => StringTableManager.IntroTable);
			this.Synergies = new AdvancedStringDBTable(() => AdvancedStringDB.SynergyTable);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00009830 File Offset: 0x00007A30
		public void LanguageChanged(StringTableManager.GungeonSupportedLanguages newLang)
		{
			this.Core.LanguageChanged();
			this.Items.LanguageChanged();
			this.Enemies.LanguageChanged();
			this.Intro.LanguageChanged();
			this.Synergies.LanguageChanged();
			Action<StringTableManager.GungeonSupportedLanguages> onLanguageChanged = this.OnLanguageChanged;
			bool flag = onLanguageChanged == null;
			if (!flag)
			{
				onLanguageChanged(newLang);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00009894 File Offset: 0x00007A94
		public static Dictionary<string, StringTableManager.StringCollection> SynergyTable
		{
			get
			{
				StringTableManager.GetSynergyString("ThisExistsOnlyToLoadTables", -1);
				return (Dictionary<string, StringTableManager.StringCollection>)AdvancedStringDB.m_synergyTable.GetValue(null);
			}
		}

		// Token: 0x04000084 RID: 132
		public readonly AdvancedStringDBTable Core;

		// Token: 0x04000085 RID: 133
		public readonly AdvancedStringDBTable Items;

		// Token: 0x04000086 RID: 134
		public readonly AdvancedStringDBTable Enemies;

		// Token: 0x04000087 RID: 135
		public readonly AdvancedStringDBTable Intro;

		// Token: 0x04000088 RID: 136
		public readonly AdvancedStringDBTable Synergies;

		// Token: 0x04000089 RID: 137
		public static FieldInfo m_synergyTable = typeof(StringTableManager).GetField("m_synergyTable", BindingFlags.Static | BindingFlags.NonPublic);

		// Token: 0x0400008A RID: 138
		public Action<StringTableManager.GungeonSupportedLanguages> OnLanguageChanged;
	}

	public sealed class AdvancedStringDBTable
	{
		/// <summary>
		/// The strings for this table.
		/// </summary>
		public Dictionary<string, StringTableManager.StringCollection> Table
		{
			get
			{
				Dictionary<string, StringTableManager.StringCollection> result;
				if ((result = _CachedTable) == null)
				{
					result = (_CachedTable = _GetTable());
				}
				return result;
			}
		}

		/// <summary>
		/// Gets or sets a string from this table using <paramref name="key"/> as the key.
		/// </summary>
		/// <param name="key">The key for the string.</param>
		/// <returns>The string.</returns>
		public StringTableManager.StringCollection this[string key]
		{
			get
			{
				return Table[key];
			}
			set
			{
				Table[key] = value;
				int num = _ChangeKeys.IndexOf(key);
				if (num > 0)
				{
					_ChangeValues[num] = value;
				}
				else
				{
					_ChangeKeys.Add(key);
					_ChangeValues.Add(value);
				}
				JournalEntry.ReloadDataSemaphore++;
			}
		}

		/// <summary>
		/// Creates a new <see cref="AdvancedStringDBTable"/>.
		/// </summary>
		/// <param name="_getTable">Method for getting the strings for the table.</param>
		public AdvancedStringDBTable(Func<Dictionary<string, StringTableManager.StringCollection>> _getTable)
		{
			_ChangeKeys = new List<string>();
			_ChangeValues = new List<StringTableManager.StringCollection>();
			_GetTable = _getTable;
		}

		/// <summary>
		/// Returns <see langword="true"/> if this string table contains <paramref name="key"/> in it's list of keys, returns <see langword="false"/> otherwise.
		/// </summary>
		/// <param name="key">The key to check.</param>
		/// <returns><see langword="true"/> if this string table contains <paramref name="key"/> in it's list of keys, <see langword="false"/> otherwise.</returns>
		public bool ContainsKey(string key)
		{
			return Table.ContainsKey(key);
		}

		/// <summary>
		/// Sets <paramref name="key"/>'s value to <paramref name="value"/> in this string table.
		/// </summary>
		/// <param name="key">The key for the string to set.</param>
		/// <param name="value">The new value for the string.</param>
		public void Set(string key, string value)
		{
			StringTableManager.StringCollection stringCollection = new StringTableManager.SimpleStringCollection();
			stringCollection.AddString(value, 1f);
			if (Table.ContainsKey(key))
			{
				Table[key] = stringCollection;
			}
			else
			{
				Table.Add(key, stringCollection);
			}
			int num = _ChangeKeys.IndexOf(key);
			if (num > 0)
			{
				_ChangeValues[num] = stringCollection;
			}
			else
			{
				_ChangeKeys.Add(key);
				_ChangeValues.Add(stringCollection);
			}
			JournalEntry.ReloadDataSemaphore++;
		}

		/// <summary>
		/// Sets <paramref name="key"/>'s value to <paramref name="values"/> in this string table.
		/// </summary>
		/// <param name="key">The key for the strings to set.</param>
		/// <param name="values">The new values for the string.</param>
		public void SetComplex(string key, params string[] values)
		{
			StringTableManager.StringCollection stringCollection = new StringTableManager.ComplexStringCollection();
			for (int i = 0; i < values.Length; i++)
			{
				string value = values[i];
				stringCollection.AddString(value, 1f);
			}
			Table[key] = stringCollection;
			int num = _ChangeKeys.IndexOf(key);
			if (num > 0)
			{
				_ChangeValues[num] = stringCollection;
			}
			else
			{
				_ChangeKeys.Add(key);
				_ChangeValues.Add(stringCollection);
			}
			JournalEntry.ReloadDataSemaphore++;
		}

		/// <summary>
		/// Sets <paramref name="key"/>'s value to <paramref name="values"/> and makes sets their weights to <paramref name="weights"/> in this string table.
		/// </summary>
		/// <param name="key">The key for the strings to set.</param>
		/// <param name="values">The new values for the string.</param>
		/// <param name="weights">The weights for the new values.</param>
		public void SetComplex(string key, List<string> values, List<float> weights)
		{
			StringTableManager.StringCollection stringCollection = new StringTableManager.ComplexStringCollection();
			for (int i = 0; i < values.Count; i++)
			{
				string value = values[i];
				float weight = weights[i];
				stringCollection.AddString(value, weight);
			}
			Table[key] = stringCollection;
			int num = _ChangeKeys.IndexOf(key);
			if (num > 0)
			{
				_ChangeValues[num] = stringCollection;
			}
			else
			{
				_ChangeKeys.Add(key);
				_ChangeValues.Add(stringCollection);
			}
			JournalEntry.ReloadDataSemaphore++;
		}

		/// <summary>
		/// Gets a string using <paramref name="key"/>
		/// </summary>
		/// <param name="key">The key for the string.</param>
		/// <returns>The found string.</returns>
		public string Get(string key)
		{
			return StringTableManager.GetString(key);
		}

		/// <summary>
		/// Makes all the new/changed strings not be lost when changing the game's language.
		/// </summary>
		public void LanguageChanged()
		{
			_CachedTable = null;
			Dictionary<string, StringTableManager.StringCollection> table = Table;
			for (int i = 0; i < _ChangeKeys.Count; i++)
			{
				table[_ChangeKeys[i]] = _ChangeValues[i];
			}
		}
		private readonly Func<Dictionary<string, StringTableManager.StringCollection>> _GetTable;
		private Dictionary<string, StringTableManager.StringCollection> _CachedTable;
		private readonly List<string> _ChangeKeys;
		private readonly List<StringTableManager.StringCollection> _ChangeValues;
	}

	class TextMaker : MonoBehaviour
	{
		dfControl nameLabel;
		public tk2dSprite sprite = null;

		public string Text;
		public Color Color;
		public float Opacity;
		public float TextSize;
		//============================//
		public dfPivotPoint anchor;
		public Vector3 offset;
		public GameObject GameObjectToAttachTo;
		//============================//
		public float FadeInTime;
		public float FadeOutTime;
		public float ExistTime;
		public float Delay;
		public bool TextDisappearsEver;
		//============================//
		private float Elapsed = 0;
		private float ExitFade;
		//============================//

		public TextMaker()
		{
			this.Text = "test";
			this.Color = Color.white;
			this.Opacity = 1;
			this.TextSize = 3;
			this.TextDisappearsEver = true;
			//============================//
			this.anchor = dfPivotPoint.TopCenter;
			this.offset = new Vector3(0, 0);
			//this.GameObjectToAttachTo = GameManager.Instance.PrimaryPlayer.gameObject;
			//============================//
			this.FadeInTime = 0;
			this.FadeOutTime = 0;
			this.ExistTime = 1;
			this.Delay = 0;

		}

		void Start()
		{

			ExistTime += FadeInTime;
			ExistTime += FadeOutTime;
			ExitFade = FadeOutTime;
			sprite = this.gameObject.GetComponent<tk2dSprite>();
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(BraveResources.Load("DamagePopupLabel", ".prefab"), GameUIRoot.Instance.transform);
			Vector3 worldPosition = base.transform.position;
			dfLabel Label = gameObject.GetComponent<dfLabel>();

			dfLabel targetLabel = Label as dfLabel;

			targetLabel.gameObject.SetActive(true);

			targetLabel.Text = this.Text;
			targetLabel.Color = this.Color;
			if (FadeInTime > 0)
			{
				targetLabel.Opacity = 0;
			}
			else
			{
				targetLabel.Opacity = this.Opacity;
			}
			targetLabel.TextScale = this.TextSize;



			//targetLabel.transform.position = dfFollowObject.ConvertWorldSpaces(worldPosition, GameManager.Instance.MainCameraController.Camera, GameUIRoot.Instance.Manager.RenderCamera).WithZ(0f);
			//targetLabel.transform.position = targetLabel.transform.position.QuantizeFloor(targetLabel.PixelsToUnits() / (Pixelator.Instance.ScaleTileScale / Pixelator.Instance.CurrentTileScale));
			//xOffSet = CalculateCenterXoffset(targetLabel);

			dfFollowObject component = targetLabel.gameObject.AddComponent<dfFollowObject>();
			component.attach = base.transform.gameObject;
			component.enabled = true;
			component.mainCamera = GameManager.Instance.MainCameraController.Camera;
			component.anchor = this.anchor;
			component.offset = new Vector3(CalculateCenterXoffset(targetLabel), 0) + this.offset;
			nameLabel = targetLabel;
		}

		float CalculateCenterXoffset(dfLabel label)
		{
			return label.GetCenter().x - label.transform.position.x;
		}
		float xOffSet = 0;

		public void Update()
		{
			dfLabel targetLabel = nameLabel as dfLabel;
			if (nameLabel != null)
			{
				if (GameManager.Instance.IsPaused)
				{

					targetLabel.IsVisible = false;
				}
				else
				{
					if (TextDisappearsEver == true && IsForceFading == false)
					{
						targetLabel.IsVisible = true;
						this.Elapsed += BraveTime.DeltaTime;
						if (Elapsed < FadeInTime && FadeInTime != 0)
						{
							float t = Elapsed / FadeInTime;
							targetLabel.Opacity = t * Opacity;
						}
						else if (Elapsed > ExistTime - FadeOutTime && FadeOutTime != 0)
						{
							float t = ExitFade / FadeOutTime;
							targetLabel.Opacity = t * Opacity;
							ExitFade -= BraveTime.DeltaTime;
						}
						else if (Elapsed > FadeInTime && Elapsed < ExistTime - FadeOutTime)
						{
							targetLabel.Opacity = Opacity;
						}
						else if (Elapsed < ExistTime && !GameManager.Instance.IsPaused)
						{
							targetLabel.Opacity = Opacity;
						}
						else if (Elapsed > ExistTime)
						{
							UnityEngine.Object.Destroy(targetLabel.gameObject);
						}
					}
					else if (IsForceFading == false)
					{
						targetLabel.IsVisible = true;
						this.Elapsed += BraveTime.DeltaTime;
						if (Elapsed < FadeInTime && FadeInTime != 0)
						{
							float t = Elapsed / FadeInTime;
							targetLabel.Opacity = t * Opacity;
						}
						else if (Elapsed > FadeInTime && Elapsed < ExistTime - FadeOutTime)
						{
							targetLabel.Opacity = Opacity;
						}
						else if (Elapsed < ExistTime && !GameManager.Instance.IsPaused)
						{
							targetLabel.Opacity = Opacity;
						}
					}
				}
			}
		}
		public void ChangeText(string text)
		{
			dfLabel targetLabel = nameLabel as dfLabel;
			if (nameLabel != null)
			{
				targetLabel.Text = text;
			}
		}
		public void ChangeColor(Color color)
		{
			dfLabel targetLabel = nameLabel as dfLabel;
			if (nameLabel != null)
			{
				targetLabel.Color = color;
			}
		}
		public void ChangeSize(float size)
		{
			dfLabel targetLabel = nameLabel as dfLabel;
			if (nameLabel != null)
			{
				targetLabel.TextScale = size;
			}
		}
		public void ChangeOffset(Vector3 vector)
		{
			dfFollowObject targetLabel = nameLabel.GetComponent<dfFollowObject>();
			if (targetLabel != null && nameLabel != null)
			{
				targetLabel.offset = vector;
			}
		}

		public void ForceFadeOut(float Length)
		{
			dfFollowObject targetLabel = nameLabel.GetComponent<dfFollowObject>();
			if (targetLabel != null && nameLabel != null)
			{
				GameManager.Instance.StartCoroutine(ForceFadeMethod(Length));
			}
		}
		private bool IsForceFading;
		private IEnumerator ForceFadeMethod(float Length)
		{
			float ExitFadeForce = Length;
			IsForceFading = true;
			dfLabel targetLabel = nameLabel as dfLabel;
			if (targetLabel != null && nameLabel != null)
			{
				this.Elapsed += BraveTime.DeltaTime;
				{
					float t = ExitFadeForce / Length;
					targetLabel.Opacity = t * Opacity;
					ExitFadeForce -= BraveTime.DeltaTime;
				}
			}

			yield break;
		}

		private void OnDestroy()
		{
			if (nameLabel != null)
			{
				if (nameLabel.gameObject != null)
				{
					UnityEngine.Object.Destroy(nameLabel.gameObject);
				}
			}
		}
	}
}

	