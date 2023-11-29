using Newtonsoft.Json;
namespace Classes;

public class RecupJson{

    public static List<racineJson> RecupJsonQuestion(string pathfile){
        try{
            using (StreamReader r = new StreamReader(pathfile))  
            {  
                string json = r.ReadToEnd();  
                List<racineJson> myDeserializedClass = JsonConvert.DeserializeObject<List<racineJson>>(json) ?? new List<racineJson>();          
                return myDeserializedClass;
            } 
        }catch (Exception){
            Console.WriteLine("JSON non trouvé!");
            Console.ReadLine();
            return null;
        }  
    }
}