using CardSystem;

namespace Stats
{
    public interface IStatModifierFactory
    {
        IStatModifier CreateModifier(SOCardConfig card);
    }
}