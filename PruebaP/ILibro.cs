namespace PruebaP
{
    public interface ILibro
    {
        int Subtotal(int impuestos);
        double TotalLibro();

        int PrecioLibro  { get; set; }

      
    }
}