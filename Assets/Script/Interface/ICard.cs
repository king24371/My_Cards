public interface CardStatus
{
    ///<summary>
    ///Card name
    /// </summary>
    string Name { get; }

    /// <summary>
    /// 種類(Mora)
    /// </summary>
    string Vow { get; }

    /// <summary>
    /// Energy
    /// </summary>
    int Ep { get; }

    /// <summary>
    /// 數值
    /// </summary>
    int Count { get; set; }
    int Count1 { get; set; }
    int Count2 { get; set; }

    void setStatus(data_card player);

    void ApplyEffect();

    void ApplyEffect(bool b);

    void Action(data_card player);
}

public interface Buff
{
    void applyBuff();
    void removeBuff();
}


