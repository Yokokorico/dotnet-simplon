using Newtonsoft.Json;
namespace Classes;

public class RecupJson{

    public static List<Root>? RecupJsonQuestion(string pathfile){
        try{
            using (StreamReader r = new StreamReader(pathfile))  
            {  
                string json = r.ReadToEnd();  
                List<Root> myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(json) ?? new List<Root>();          
                return myDeserializedClass;
            } 
        }catch (Exception){
            Console.WriteLine("JSON non trouvé!");
            Console.ReadLine();
            return null;
        }  
    }
}