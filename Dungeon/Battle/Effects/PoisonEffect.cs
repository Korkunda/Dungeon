using Dungeon.Char;
using Dungeon.UserInterface;

namespace Dungeon.Battling
{
    public class PoisonEffect : EndOfTurnEffect
    {


        int DmgMultiplier;
        public PoisonEffect()
        {
            TurnsLeftOfEffect = -1;
            DmgMultiplier = 1;

        }
        public override void UseEndOfTurnEffect(Character character, UIBattle uiBattle, string moveType) 
        { 
            int dmg = Convert.ToInt32(character.Stats.Health.BaseStat.Value * 0.04 * DmgMultiplier);
            character.Stats.TakeDamage(dmg);
            uiBattle.Messages.EffectMsg(character.Name, EndOfTurnMsg());
            DmgMultiplier = DmgMultiplier * 2;
        }

        public override bool UseImmediateEffect(Character character, UIBattle uiBattle, string moveType)
        {
            throw new NotImplementedException();
        }
        public string ImmediateEffectMsg()
        {
            return "was poisoned!";
        }

        public string EndOfTurnMsg()
        {
            return "is hurt by poison.";
        }


    }
}
