public class HomeController{
    

    [HttpPost]
    public ActionResult Index(string usr, string pwd, string rme)
    {
        // Aquí cualquier uso de las variables 'usr', 'pwd' y 'rme'
        return View("Index");
    }
}