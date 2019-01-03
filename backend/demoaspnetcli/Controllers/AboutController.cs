using Microsoft.AspNetCore.Mvc;

namespace demoaspnetcli.Controllers{
    [Route("[controller]")]
    public class AboutController {

        [Route("")]
        public string Phone(){
            return "0810000001";
        }
        [Route("address")]
        public string Address(){
            return "Palazzo Regus";
        }
    }

}