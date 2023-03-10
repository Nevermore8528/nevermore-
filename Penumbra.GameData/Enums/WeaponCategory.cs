using System;

namespace Penumbra.GameData.Enums;

public enum WeaponCategory : byte
{
    Unknown = 0,
    Pugilist,
    Gladiator,
    Marauder,
    Archer,
    Lancer,
    Thaumaturge1,
    Thaumaturge2,
    Conjurer1,
    Conjurer2,
    Arcanist,
    Shield,
    CarpenterMain,
    CarpenterOff,
    BlacksmithMain,
    BlacksmithOff,
    ArmorerMain,
    ArmorerOff,
    GoldsmithMain,
    GoldsmithOff,
    LeatherworkerMain,
    LeatherworkerOff,
    WeaverMain,
    WeaverOff,
    AlchemistMain,
    AlchemistOff,
    CulinarianMain,
    CulinarianOff,
    MinerMain,
    MinerOff,
    BotanistMain,
    BotanistOff,
    FisherMain,
    Rogue       = 84,
    DarkKnight  = 87,
    Machinist   = 88,
    Astrologian = 89,
    Samurai     = 96,
    RedMage     = 97,
    Scholar     = 98,
    FisherOff   = 99,
    BlueMage    = 105,
    Gunbreaker  = 106,
    Dancer      = 107,
    Reaper      = 108,
    Sage        = 109,
}

public static class WeaponCategoryExtensions
{
    public static WeaponCategory AllowsOffHand( this WeaponCategory category )
        => category switch
        {
            WeaponCategory.Pugilist          => WeaponCategory.Pugilist,
            WeaponCategory.Gladiator         => WeaponCategory.Shield,
            WeaponCategory.Marauder          => WeaponCategory.Unknown,
            WeaponCategory.Archer            => WeaponCategory.Unknown,
            WeaponCategory.Lancer            => WeaponCategory.Unknown,
            WeaponCategory.Thaumaturge1      => WeaponCategory.Shield,
            WeaponCategory.Thaumaturge2      => WeaponCategory.Unknown,
            WeaponCategory.Conjurer1         => WeaponCategory.Shield,
            WeaponCategory.Conjurer2         => WeaponCategory.Unknown,
            WeaponCategory.Arcanist          => WeaponCategory.Unknown,
            WeaponCategory.Shield            => WeaponCategory.Unknown,
            WeaponCategory.CarpenterMain     => WeaponCategory.CarpenterOff,
            WeaponCategory.CarpenterOff      => WeaponCategory.Unknown,
            WeaponCategory.BlacksmithMain    => WeaponCategory.BlacksmithOff,
            WeaponCategory.BlacksmithOff     => WeaponCategory.Unknown,
            WeaponCategory.ArmorerMain       => WeaponCategory.ArmorerOff,
            WeaponCategory.ArmorerOff        => WeaponCategory.Unknown,
            WeaponCategory.GoldsmithMain     => WeaponCategory.GoldsmithOff,
            WeaponCategory.GoldsmithOff      => WeaponCategory.Unknown,
            WeaponCategory.LeatherworkerMain => WeaponCategory.LeatherworkerOff,
            WeaponCategory.LeatherworkerOff  => WeaponCategory.Unknown,
            WeaponCategory.WeaverMain        => WeaponCategory.WeaverOff,
            WeaponCategory.WeaverOff         => WeaponCategory.Unknown,
            WeaponCategory.AlchemistMain     => WeaponCategory.AlchemistOff,
            WeaponCategory.AlchemistOff      => WeaponCategory.Unknown,
            WeaponCategory.CulinarianMain    => WeaponCategory.CulinarianOff,
            WeaponCategory.CulinarianOff     => WeaponCategory.Unknown,
            WeaponCategory.MinerMain         => WeaponCategory.MinerOff,
            WeaponCategory.MinerOff          => WeaponCategory.Unknown,
            WeaponCategory.BotanistMain      => WeaponCategory.BotanistOff,
            WeaponCategory.BotanistOff       => WeaponCategory.Unknown,
            WeaponCategory.FisherMain        => WeaponCategory.FisherOff,
            WeaponCategory.Rogue             => WeaponCategory.Rogue,
            WeaponCategory.DarkKnight        => WeaponCategory.Unknown,
            WeaponCategory.Machinist         => WeaponCategory.Machinist,
            WeaponCategory.Astrologian       => WeaponCategory.Astrologian,
            WeaponCategory.Samurai           => WeaponCategory.Unknown,
            WeaponCategory.RedMage           => WeaponCategory.RedMage,
            WeaponCategory.Scholar           => WeaponCategory.Unknown,
            WeaponCategory.FisherOff         => WeaponCategory.Unknown,
            WeaponCategory.BlueMage          => WeaponCategory.Unknown,
            WeaponCategory.Gunbreaker        => WeaponCategory.Unknown,
            WeaponCategory.Dancer            => WeaponCategory.Dancer,
            WeaponCategory.Reaper            => WeaponCategory.Unknown,
            WeaponCategory.Sage              => WeaponCategory.Unknown,
            _                                => WeaponCategory.Unknown,
        };

    public static EquipSlot ToSlot( this WeaponCategory category )
        => category switch
        {
            WeaponCategory.Pugilist          => EquipSlot.MainHand,
            WeaponCategory.Gladiator         => EquipSlot.MainHand,
            WeaponCategory.Marauder          => EquipSlot.MainHand,
            WeaponCategory.Archer            => EquipSlot.MainHand,
            WeaponCategory.Lancer            => EquipSlot.MainHand,
            WeaponCategory.Thaumaturge1      => EquipSlot.MainHand,
            WeaponCategory.Thaumaturge2      => EquipSlot.MainHand,
            WeaponCategory.Conjurer1         => EquipSlot.MainHand,
            WeaponCategory.Conjurer2         => EquipSlot.MainHand,
            WeaponCategory.Arcanist          => EquipSlot.MainHand,
            WeaponCategory.Shield            => EquipSlot.OffHand,
            WeaponCategory.CarpenterMain     => EquipSlot.MainHand,
            WeaponCategory.CarpenterOff      => EquipSlot.OffHand,
            WeaponCategory.BlacksmithMain    => EquipSlot.MainHand,
            WeaponCategory.BlacksmithOff     => EquipSlot.OffHand,
            WeaponCategory.ArmorerMain       => EquipSlot.MainHand,
            WeaponCategory.ArmorerOff        => EquipSlot.OffHand,
            WeaponCategory.GoldsmithMain     => EquipSlot.MainHand,
            WeaponCategory.GoldsmithOff      => EquipSlot.OffHand,
            WeaponCategory.LeatherworkerMain => EquipSlot.MainHand,
            WeaponCategory.LeatherworkerOff  => EquipSlot.OffHand,
            WeaponCategory.WeaverMain        => EquipSlot.MainHand,
            WeaponCategory.WeaverOff         => EquipSlot.OffHand,
            WeaponCategory.AlchemistMain     => EquipSlot.MainHand,
            WeaponCategory.AlchemistOff      => EquipSlot.OffHand,
            WeaponCategory.CulinarianMain    => EquipSlot.MainHand,
            WeaponCategory.CulinarianOff     => EquipSlot.OffHand,
            WeaponCategory.MinerMain         => EquipSlot.MainHand,
            WeaponCategory.MinerOff          => EquipSlot.OffHand,
            WeaponCategory.BotanistMain      => EquipSlot.MainHand,
            WeaponCategory.BotanistOff       => EquipSlot.OffHand,
            WeaponCategory.FisherMain        => EquipSlot.MainHand,
            WeaponCategory.Rogue             => EquipSlot.MainHand,
            WeaponCategory.DarkKnight        => EquipSlot.MainHand,
            WeaponCategory.Machinist         => EquipSlot.MainHand,
            WeaponCategory.Astrologian       => EquipSlot.MainHand,
            WeaponCategory.Samurai           => EquipSlot.MainHand,
            WeaponCategory.RedMage           => EquipSlot.MainHand,
            WeaponCategory.Scholar           => EquipSlot.MainHand,
            WeaponCategory.FisherOff         => EquipSlot.OffHand,
            WeaponCategory.BlueMage          => EquipSlot.MainHand,
            WeaponCategory.Gunbreaker        => EquipSlot.MainHand,
            WeaponCategory.Dancer            => EquipSlot.MainHand,
            WeaponCategory.Reaper            => EquipSlot.MainHand,
            WeaponCategory.Sage              => EquipSlot.MainHand,
            _                                => EquipSlot.Unknown,
        };

    public static int ToIndex( this WeaponCategory category )
        => category switch
        {
            WeaponCategory.Pugilist          => 0,
            WeaponCategory.Gladiator         => 1,
            WeaponCategory.Marauder          => 2,
            WeaponCategory.Archer            => 3,
            WeaponCategory.Lancer            => 4,
            WeaponCategory.Thaumaturge1      => 5,
            WeaponCategory.Thaumaturge2      => 6,
            WeaponCategory.Conjurer1         => 7,
            WeaponCategory.Conjurer2         => 8,
            WeaponCategory.Arcanist          => 9,
            WeaponCategory.Shield            => 10,
            WeaponCategory.CarpenterMain     => 11,
            WeaponCategory.CarpenterOff      => 12,
            WeaponCategory.BlacksmithMain    => 13,
            WeaponCategory.BlacksmithOff     => 14,
            WeaponCategory.ArmorerMain       => 15,
            WeaponCategory.ArmorerOff        => 16,
            WeaponCategory.GoldsmithMain     => 17,
            WeaponCategory.GoldsmithOff      => 18,
            WeaponCategory.LeatherworkerMain => 19,
            WeaponCategory.LeatherworkerOff  => 20,
            WeaponCategory.WeaverMain        => 21,
            WeaponCategory.WeaverOff         => 22,
            WeaponCategory.AlchemistMain     => 23,
            WeaponCategory.AlchemistOff      => 24,
            WeaponCategory.CulinarianMain    => 25,
            WeaponCategory.CulinarianOff     => 26,
            WeaponCategory.MinerMain         => 27,
            WeaponCategory.MinerOff          => 28,
            WeaponCategory.BotanistMain      => 29,
            WeaponCategory.BotanistOff       => 30,
            WeaponCategory.FisherMain        => 31,
            WeaponCategory.Rogue             => 32,
            WeaponCategory.DarkKnight        => 33,
            WeaponCategory.Machinist         => 34,
            WeaponCategory.Astrologian       => 35,
            WeaponCategory.Samurai           => 36,
            WeaponCategory.RedMage           => 37,
            WeaponCategory.Scholar           => 38,
            WeaponCategory.FisherOff         => 39,
            WeaponCategory.BlueMage          => 40,
            WeaponCategory.Gunbreaker        => 41,
            WeaponCategory.Dancer            => 42,
            WeaponCategory.Reaper            => 43,
            WeaponCategory.Sage              => 44,
            _                                => -1,
        };
}