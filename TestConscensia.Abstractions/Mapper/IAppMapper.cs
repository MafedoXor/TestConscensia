namespace TestConscensia.Abstractions.Mapper
{
    public interface IAppMapper
    {
        void InitMapper();
        TDes Map<TSource, TDes>(TSource source);
        TDes Map<TDes>(object source);

    }
}
