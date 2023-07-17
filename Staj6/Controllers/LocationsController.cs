using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Staj6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly DataContext _context;
        public LocationsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]

        public Response Add(Locationn _location) // string response yapıldı
        {
            var _response1 = new Response();

            _location.Name.Trim();

            if (_location.Name == "string" || _location.X == 0 || _location.Y == 0)
            {

                _response1.Result = "Null değer girmeyiniz.";
            }
            else
            {
                var eklenen = (from _context in _context.locationnss where _context.Name.ToUpper() == _location.Name.ToUpper() select _context).FirstOrDefault(); 
                              
                if (eklenen == null)
                {
                    _context.locationnss.Add(_location);
                    _context.SaveChanges();
                    _response1.Result = "Eklendi.";
                }
                else
                {
                    _response1.Result = "Önceden eklenmişti";
                }

            }

            return _response1;


        }

        [HttpGet]
        [Route("getAll")]
        public Response GetAll()
        {
            var response = new Response();
            response.Value = (from _context in _context.locationnss select _context).OrderBy(r => r.Id).ToList();
        
            // _context.locationnss.OrderBy(r => r.Id).ToList();
            //_context.SaveChanges();
            response.Result = "getirildi";
            return response;


        }



        [HttpPut]
        public Response Update(Locationn _location, int id)
        {
            var _response = new Response();
            var eklenen = (from _context in _context.locationnss where _context.Name == _location.Name select _context).FirstOrDefault();
            var arama = _context.locationnss.FirstOrDefault(x => x.Id == id);

            // Location arama=_context.LinqLocations.Single(x=>x.Id==_location.Id);


            if (arama != null)
            {
                if (_location.Name != "string" && eklenen == null)
                {
                    arama.Name = _location.Name;
                }
                if (_location.Name != null)
                {
                    arama.Name = _location.Name;
                }
                if (_location.X != 0)
                {
                    arama.X = _location.X;
                }
                if (_location.Y != 0)
                {
                    arama.Y = _location.Y;
                }
                _context.SaveChanges();
                _response.Result = "kayıt güncellendi";
            }
            else
            {
                _response.Result = "böyle bir kayıt yok";
            }
            return _response;
        }
    
    //[HttpPut]
    //public Response Update(Locationn loc) //string response edildi
    //{
    //    var _response2 = new Response();
    //    // _context.Locations.Update(loc);
    //    // _context.SaveChanges();
    //    var deg = (from idget in _context.locationnss where idget.Id == loc.Id select idget).FirstOrDefault();
    //    //_context.locationnss.Find(loc.Id);
    //    if (deg != null)
    //    {
    //        if (loc.Name != "string")
    //        {
    //            deg.Name = loc.Name;

    //        }
    //        if (loc.X != 0)
    //        {
    //            deg.X = loc.X;

    //        }
    //        if (loc.Y != 0)
    //        {
    //            deg.Y = loc.Y;
    //        }
    //        _context.SaveChanges();
    //        _response2.Result = "Güncellendi.";

    //    }
    //    else
    //    {
    //        _response2.Result = "Güncellenmedi";

    //    }

    //    return _response2;

    //}
    //[HttpPut]
    //public Response Update(Locationn loc) //string response edildi
    //{
    //    var _response2 = new Response();
    //    // _context.Locations.Update(loc);
    //    // _context.SaveChanges();
    //    var deg = (from idget in _context.locationnss where idget.Id == loc.Id select idget).FirstOrDefault();
    //    //_context.locationnss.Find(loc.Id);
    //    if (deg != null)
    //    {
    //        if (loc.Name != "string")
    //        {
    //            deg.Name = loc.Name;

    //        }
    //        if (loc.X != 0)
    //        {
    //            deg.X = loc.X;

    //        }
    //        if (loc.Y != 0)
    //        {
    //            deg.Y = loc.Y;        
    //        }
    //        _context.SaveChanges();
    //        _response2.Result = "Güncellendi.";

    //    }
    //    else
    //    {
    //          _response2.Result = "Güncellenmedi";

    //    }

    //    return _response2;

    //}

    [HttpDelete("{id}")]

        public Response Delete(int id) //string response edildi sonra sildim
        {
            var _response3 = new Response();
            var silme = (from _context in _context.locationnss where _context.Id == id select _context).SingleOrDefault();
            if (silme != null)
            {
                _context.locationnss.RemoveRange(silme);
                _context.SaveChanges();
                _response3.Result = "Kayıt silindi";

            }
            else
            {
                _response3.Result = "Kayıt silinemedi";
            }
            return _response3;




        }
        [HttpGet("id")]
        public Response GetById(int id)
        {
            var _response = new Response();

            var idalma = from _context in _context.locationnss where _context.Id == id select _context;
            //_context.locationnss.Find(id);
            if (idalma != null)
            {
                _response.Value = idalma;
                _response.Result = "Id bulundu";
            }
            else
            {
                _response.Result = "Id'yi alamadı";

            }
            //_context.SaveChanges();
            return _response;





        }
    }
}
