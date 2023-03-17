using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace WC3Tool;

public class WC3_editor_givegg : Form
{
	private IContainer components;

	private ComboBox species_box;

	private Label label1;

	private ComboBox move_box;

	private Label label2;

	private ComboBox game_box;

	private ComboBox lang_box;

	private Label label3;

	private Label label4;

	private Button save_but;

	private Button cancel_but;

	public WC3_editor_givegg()
	{
		InitializeComponent();
		game_box.SelectedIndex = 0;
		lang_box.SelectedIndex = 1;
		species_box.SelectedIndex = 172;
		move_box.SelectedIndex = 57;
	}

	private void Save_butClick(object sender, EventArgs e)
	{
		string text = ((game_box.SelectedIndex != 1) ? "E" : "FR");
		string text2 = "Eng";
		switch (lang_box.SelectedIndex)
		{
		case 0:
			text2 = "Jap";
			break;
		case 1:
			text2 = "Eng";
			break;
		case 2:
			text2 = "Fre";
			break;
		case 3:
			text2 = "Ita";
			break;
		case 4:
			text2 = "Deu";
			break;
		case 5:
			text2 = "Esp";
			break;
		}
		byte[] array = (byte[])new ResourceManager("WC3Tool.WC3.GiveEggOrg", Assembly.GetExecutingAssembly()).GetObject("ROM_" + text + "_GiveEgg_" + text2);
		ushort value = (ushort)move_box.SelectedIndex;
		BitConverter.GetBytes(value).ToArray().CopyTo(array, 134);
		BitConverter.GetBytes(value).ToArray().CopyTo(array, 140);
		BitConverter.GetBytes(value).ToArray().CopyTo(array, 146);
		BitConverter.GetBytes(value).ToArray().CopyTo(array, 152);
		BitConverter.GetBytes(value).ToArray().CopyTo(array, 158);
		BitConverter.GetBytes((ushort)species_box.SelectedIndex).ToArray().CopyTo(array, 66);
		WC3_editor.wc3file.set_script(array);
		WC3_editor.script_injected = true;
		Close();
	}

	private void Cancel_butClick(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.species_box = new System.Windows.Forms.ComboBox();
		this.label1 = new System.Windows.Forms.Label();
		this.move_box = new System.Windows.Forms.ComboBox();
		this.label2 = new System.Windows.Forms.Label();
		this.game_box = new System.Windows.Forms.ComboBox();
		this.lang_box = new System.Windows.Forms.ComboBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.save_but = new System.Windows.Forms.Button();
		this.cancel_but = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.species_box.FormattingEnabled = true;
		this.species_box.Items.AddRange(new object[440]
		{
			"NONE", "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise",
			"Caterpie", "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata",
			"Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Sandshrew", "Sandslash", "Nidoran♀",
			"Nidorina", "Nidoqueen", "Nidoran♂", "Nidorino", "Nidoking", "Clefairy", "Clefable", "Vulpix", "Ninetales", "Jigglypuff",
			"Wigglytuff", "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth",
			"Diglett", "Dugtrio", "Meowth", "Persian", "Psyduck", "Golduck", "Mankey", "Primeape", "Growlithe", "Arcanine",
			"Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout",
			"Weepinbell", "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Graveler", "Golem", "Ponyta", "Rapidash", "Slowpoke",
			"Slowbro", "Magnemite", "Magneton", "Farfetch'd", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Muk",
			"Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno", "Krabby", "Kingler",
			"Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Cubone", "Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing",
			"Weezing", "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking",
			"Staryu", "Starmie", "Mr. Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp",
			"Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar",
			"Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite",
			"Mewtwo", "Mew", "Chikorita", "Bayleef", "Meganium", "Cyndaquil", "Quilava", "Typhlosion", "Totodile", "Croconaw",
			"Feraligatr", "Sentret", "Furret", "Hoothoot", "Noctowl", "Ledyba", "Ledian", "Spinarak", "Ariados", "Crobat",
			"Chinchou", "Lanturn", "Pichu", "Cleffa", "Igglybuff", "Togepi", "Togetic", "Natu", "Xatu", "Mareep",
			"Flaaffy", "Ampharos", "Bellossom", "Marill", "Azumarill", "Sudowoodo", "Politoed", "Hoppip", "Skiploom", "Jumpluff",
			"Aipom", "Sunkern", "Sunflora", "Yanma", "Wooper", "Quagsire", "Espeon", "Umbreon", "Murkrow", "Slowking",
			"Misdreavus", "Unown A", "Wobbuffet", "Girafarig", "Pineco", "Forretress", "Dunsparce", "Gligar", "Steelix", "Snubbull",
			"Granbull", "Qwilfish", "Scizor", "Shuckle", "Heracross", "Sneasel", "Teddiursa", "Ursaring", "Slugma", "Magcargo",
			"Swinub", "Piloswine", "Corsola", "Remoraid", "Octillery", "Delibird", "Mantine", "Skarmory", "Houndour", "Houndoom",
			"Kingdra", "Phanpy", "Donphan", "Porygon2", "Stantler", "Smeargle", "Tyrogue", "Hitmontop", "Smoochum", "Elekid",
			"Magby", "Miltank", "Blissey", "Raikou", "Entei", "Suicune", "Larvitar", "Pupitar", "Tyranitar", "Lugia",
			"Ho-oh", "Celebi", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)",
			"? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)",
			"? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "? (glitch Pokémon)", "Treecko", "Grovyle", "Sceptile",
			"Torchic", "Combusken", "Blaziken", "Mudkip", "Marshtomp", "Swampert", "Poochyena", "Mightyena", "Zigzagoon", "Linoone",
			"Wurmple", "Silcoon", "Beautifly", "Cascoon", "Dustox", "Lotad", "Lombre", "Ludicolo", "Seedot", "Nuzleaf",
			"Shiftry", "Nincada", "Ninjask", "Shedinja", "Taillow", "Swellow", "Shroomish", "Breloom", "Spinda", "Wingull",
			"Pelipper", "Surskit", "Masquerain", "Wailmer", "Wailord", "Skitty", "Delcatty", "Kecleon", "Baltoy", "Claydol",
			"Nosepass", "Torkoal", "Sableye", "Barboach", "Whiscash", "Luvdisc", "Corphish", "Crawdaunt", "Feebas", "Milotic",
			"Carvanha", "Sharpedo", "Trapinch", "Vibrava", "Flygon", "Makuhita", "Hariyama", "Electrike", "Manectric", "Numel",
			"Camerupt", "Spheal", "Sealeo", "Walrein", "Cacnea", "Cacturne", "Snorunt", "Glalie", "Lunatone", "Solrock",
			"Azurill", "Spoink", "Grumpig", "Plusle", "Minun", "Mawile", "Meditite", "Medicham", "Swablu", "Altaria",
			"Wynaut", "Duskull", "Dusclops", "Roselia", "Slakoth", "Vigoroth", "Slaking", "Gulpin", "Swalot", "Tropius",
			"Whismur", "Loudred", "Exploud", "Clamperl", "Huntail", "Gorebyss", "Absol", "Shuppet", "Banette", "Seviper",
			"Zangoose", "Relicanth", "Aron", "Lairon", "Aggron", "Castform", "Volbeat", "Illumise", "Lileep", "Cradily",
			"Anorith", "Armaldo", "Ralts", "Kirlia", "Gardevoir", "Bagon", "Shelgon", "Salamence", "Beldum", "Metang",
			"Metagross", "Regirock", "Regice", "Registeel", "Kyogre", "Groudon", "Rayquaza", "Latias", "Latios", "Jirachi",
			"Deoxys", "Chimecho", "Pokémon Egg", "Unown B", "Unown C", "Unown D", "Unown E", "Unown F", "Unown G", "Unown H",
			"Unown I", "Unown J", "Unown K", "Unown L", "Unown M", "Unown N", "Unown O", "Unown P", "Unown Q", "Unown R",
			"Unown S", "Unown T", "Unown U", "Unown V", "Unown W", "Unown X", "Unown Y", "Unown Z", "Unown !", "Unown ?"
		});
		this.species_box.Location = new System.Drawing.Point(12, 69);
		this.species_box.Name = "species_box";
		this.species_box.Size = new System.Drawing.Size(170, 21);
		this.species_box.TabIndex = 0;
		this.label1.Location = new System.Drawing.Point(12, 51);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(100, 15);
		this.label1.TabIndex = 1;
		this.label1.Text = "Pokemon:";
		this.move_box.FormattingEnabled = true;
		this.move_box.Items.AddRange(new object[355]
		{
			"-NONE-", "Pound", "Karate Chop*", "Double Slap", "Comet Punch", "Mega Punch", "Pay Day", "Fire Punch", "Ice Punch", "Thunder Punch",
			"Scratch", "Vice Grip", "Guillotine", "Razor Wind", "Swords Dance", "Cut", "Gust*", "Wing Attack", "Whirlwind", "Fly",
			"Bind", "Slam", "Vine Whip", "Stomp", "Double Kick", "Mega Kick", "Jump Kick", "Rolling Kick", "Sand Attack*", "Headbutt",
			"Horn Attack", "Fury Attack", "Horn Drill", "Tackle", "Body Slam", "Wrap", "Take Down", "Thrash", "Double-Edge", "Tail Whip",
			"Poison Sting", "Twineedle", "Pin Missile", "Leer", "Bite*", "Growl", "Roar", "Sing", "Supersonic", "Sonic Boom",
			"Disable", "Acid", "Ember", "Flamethrower", "Mist", "Water Gun", "Hydro Pump", "Surf", "Ice Beam", "Blizzard",
			"Psybeam", "Bubble Beam", "Aurora Beam", "Hyper Beam", "Peck", "Drill Peck", "Submission", "Low Kick", "Counter", "Seismic Toss",
			"Strength", "Absorb", "Mega Drain", "Leech Seed", "Growth", "Razor Leaf", "Solar Beam", "Poison Powder", "Stun Spore", "Sleep Powder",
			"Petal Dance", "String Shot", "Dragon Rage", "Fire Spin", "Thunder Shock", "Thunderbolt", "Thunder Wave", "Thunder", "Rock Throw", "Earthquake",
			"Fissure", "Dig", "Toxic", "Confusion", "Psychic", "Hypnosis", "Meditate", "Agility", "Quick Attack", "Rage",
			"Teleport", "Night Shade", "Mimic", "Screech", "Double Team", "Recover", "Harden", "Minimize", "Smokescreen", "Confuse Ray",
			"Withdraw", "Defense Curl", "Barrier", "Light Screen", "Haze", "Reflect", "Focus Energy", "Bide", "Metronome", "Mirror Move",
			"Self-Destruct", "Egg Bomb", "Lick", "Smog", "Sludge", "Bone Club", "Fire Blast", "Waterfall", "Clamp", "Swift",
			"Skull Bash", "Spike Cannon", "Constrict", "Amnesia", "Kinesis", "Soft-Boiled", "High Jump Kick", "Glare", "Dream Eater", "Poison Gas",
			"Barrage", "Leech Life", "Lovely Kiss", "Sky Attack", "Transform", "Bubble", "Dizzy Punch", "Spore", "Flash", "Psywave",
			"Splash", "Acid Armor", "Crabhammer", "Explosion", "Fury Swipes", "Bonemerang", "Rest", "Rock Slide", "Hyper Fang", "Sharpen",
			"Conversion", "Tri Attack", "Super Fang", "Slash", "Substitute", "Struggle", "Sketch", "Triple Kick", "Thief", "Spider Web",
			"Mind Reader", "Nightmare", "Flame Wheel", "Snore", "Curse*", "Flail", "Conversion 2", "Aeroblast", "Cotton Spore", "Reversal",
			"Spite", "Powder Snow", "Protect", "Mach Punch", "Scary Face", "Feint Attack", "Sweet Kiss*", "Belly Drum", "Sludge Bomb", "Mud-Slap",
			"Octazooka", "Spikes", "Zap Cannon", "Foresight", "Destiny Bond", "Perish Song", "Icy Wind", "Detect", "Bone Rush", "Lock-On",
			"Outrage", "Sandstorm", "Giga Drain", "Endure", "Charm*", "Rollout", "False Swipe", "Swagger", "Milk Drink", "Spark",
			"Fury Cutter", "Steel Wing", "Mean Look", "Attract", "Sleep Talk", "Heal Bell", "Return", "Present", "Frustration", "Safeguard",
			"Pain Split", "Sacred Fire", "Magnitude", "Dynamic Punch", "Megahorn", "Dragon Breath", "Baton Pass", "Encore", "Pursuit", "Rapid Spin",
			"Sweet Scent", "Iron Tail", "Metal Claw", "Vital Throw", "Morning Sun", "Synthesis", "Moonlight*", "Hidden Power", "Cross Chop", "Twister",
			"Rain Dance", "Sunny Day", "Crunch", "Mirror Coat", "Psych Up", "Extreme Speed", "Ancient Power", "Shadow Ball", "Future Sight", "Rock Smash",
			"Whirlpool", "Beat Up", "Fake Out", "Uproar", "Stockpile", "Spit Up", "Swallow", "Heat Wave", "Hail", "Torment",
			"Flatter", "Will-O-Wisp", "Memento", "Facade", "Focus Punch", "Smelling Salts", "Follow Me", "Nature Power", "Charge", "Taunt",
			"Helping Hand", "Trick", "Role Play", "Wish", "Assist", "Ingrain", "Superpower", "Magic Coat", "Recycle", "Revenge",
			"Brick Break", "Yawn", "Knock Off", "Endeavor", "Eruption", "Skill Swap", "Imprison", "Refresh", "Grudge", "Snatch",
			"Secret Power", "Dive", "Arm Thrust", "Camouflage", "Tail Glow", "Luster Purge", "Mist Ball", "Feather Dance", "Teeter Dance", "Blaze Kick",
			"Mud Sport", "Ice Ball", "Needle Arm", "Slack Off", "Hyper Voice", "Poison Fang", "Crush Claw", "Blast Burn", "Hydro Cannon", "Meteor Mash",
			"Astonish", "Weather Ball", "Aromatherapy", "Fake Tears", "Air Cutter", "Overheat", "Odor Sleuth", "Rock Tomb", "Silver Wind", "Metal Sound",
			"Grass Whistle", "Tickle", "Cosmic Power", "Water Spout", "Signal Beam", "Shadow Punch", "Extrasensory", "Sky Uppercut", "Sand Tomb", "Sheer Cold",
			"Muddy Water", "Bullet Seed", "Aerial Ace", "Icicle Spear", "Iron Defense", "Block", "Howl", "Dragon Claw", "Frenzy Plant", "Bulk Up",
			"Bounce", "Mud Shot", "Poison Tail", "Covet", "Volt Tackle", "Magical Leaf", "Water Sport", "Calm Mind", "Leaf Blade", "Dragon Dance",
			"Rock Blast", "Shock Wave", "Water Pulse", "Doom Desire", "Psycho Boost"
		});
		this.move_box.Location = new System.Drawing.Point(188, 69);
		this.move_box.Name = "move_box";
		this.move_box.Size = new System.Drawing.Size(170, 21);
		this.move_box.TabIndex = 2;
		this.label2.Location = new System.Drawing.Point(188, 51);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(100, 15);
		this.label2.TabIndex = 3;
		this.label2.Text = "Special Move:";
		this.game_box.FormattingEnabled = true;
		this.game_box.Items.AddRange(new object[2] { "Emerald", "Fire Red / Leaf Green" });
		this.game_box.Location = new System.Drawing.Point(12, 27);
		this.game_box.Name = "game_box";
		this.game_box.Size = new System.Drawing.Size(170, 21);
		this.game_box.TabIndex = 4;
		this.lang_box.FormattingEnabled = true;
		this.lang_box.Items.AddRange(new object[6] { "Japanese", "English", "French", "Italian", "German", "Spanish" });
		this.lang_box.Location = new System.Drawing.Point(188, 27);
		this.lang_box.Name = "lang_box";
		this.lang_box.Size = new System.Drawing.Size(170, 21);
		this.lang_box.TabIndex = 5;
		this.label3.Location = new System.Drawing.Point(12, 9);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(100, 15);
		this.label3.TabIndex = 6;
		this.label3.Text = "Game:";
		this.label4.Location = new System.Drawing.Point(188, 9);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(100, 15);
		this.label4.TabIndex = 7;
		this.label4.Text = "Language:";
		this.save_but.Location = new System.Drawing.Point(107, 96);
		this.save_but.Name = "save_but";
		this.save_but.Size = new System.Drawing.Size(75, 23);
		this.save_but.TabIndex = 8;
		this.save_but.Text = "Inject";
		this.save_but.UseVisualStyleBackColor = true;
		this.save_but.Click += new System.EventHandler(Save_butClick);
		this.cancel_but.Location = new System.Drawing.Point(188, 96);
		this.cancel_but.Name = "cancel_but";
		this.cancel_but.Size = new System.Drawing.Size(75, 23);
		this.cancel_but.TabIndex = 9;
		this.cancel_but.Text = "Cancel";
		this.cancel_but.UseVisualStyleBackColor = true;
		this.cancel_but.Click += new System.EventHandler(Cancel_butClick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(371, 127);
		base.Controls.Add(this.cancel_but);
		base.Controls.Add(this.save_but);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.lang_box);
		base.Controls.Add(this.game_box);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.move_box);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.species_box);
		base.Name = "WC3_editor_givegg";
		this.Text = "ROM Give Egg Script";
		base.ResumeLayout(false);
	}
}
