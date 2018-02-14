//Clase que retornara o enviara la lista de Elementos
//que seran mostrados en la ListView

namespace ScrollInf
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataService
    {
        private readonly List<string> _data = new List<string>
        {
            "Mohamed", "Hassen", "Omar", "Ali", "Othman", "Adam", "Seif", "Hamed", "Paul",
            "David", "Fehmi", "Badr", "Hamza", "Nabil", "Hajer", "Sami", "Ahmed", "Amir",
            "Nebrass", "Karim", "Cherif", "Alaa", "Samar", "Narjess", "Iheb", "Safa",
            "Mohamed", "Hassen", "Omar", "Ali", "Othman", "Adam", "Seif", "Hamed", "Paul",
            "David", "Fehmi", "Badr", "Hamza", "Nabil", "Hajer", "Sami", "Ahmed", "Amir",
        };

        /*
         Este metodo se encarga de asignar el retardo para mostrar los elementos
         y
         Mostrar ciertos elementos (indicados por parametros) y omitir el resto
             */
        public async Task<List<string>> GetItemsAsync(int pageIndex, int pageSize)
        {
            //asigna un retardo

            await Task.Delay(2000);

            //Skip omite una serie de elementos en una secuencia y devuelve los restantes

            //Take Devuele un num especifico de elementos contiguos desde el
            //principio de una secuencia

            return _data.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
    }
}
