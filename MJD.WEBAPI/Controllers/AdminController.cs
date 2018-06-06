using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJD.DAL;
using MJD.MODEL;
using Microsoft.AspNetCore.Cors;
using MJD.COMMON;

namespace MJD.WEBAPI.Controllers
{
    
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("[action]")]
        public rtData Add([FromBody]M_ADMIN form)
        {
            D_ADMIN dalObj = new D_ADMIN();
            TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);
            Console.WriteLine("Name:{0}, TeleNum:{1}", form.Name, form.TeleNum);

            COMMON.MySqlRtMsg rtMsg = dalObj.Add(new M_ADMIN(){
                ID = 0,
                RID = 2,
                Name = form.Name,
                TeleNum = form.TeleNum,
                CreateTime = (long)ts.TotalMilliseconds,
                CreateIP = "",
                Status = 1
            });
            if(rtMsg.errCode == 1){
                return List(new Pagination(){
                    pageSize = 5,
                    currentPage = -1
                });
            }else{
                return new rtData(rtMsg);
            }
        }

        [HttpGet("[action]")]
        public rtData List([FromQuery]Pagination pg)
        {
            COMMON.MySqlRtMsg rtMsg = new COMMON.MySqlRtMsg();

            DataSet ds = new D_ADMIN().GetPagination(
                new M_ADMIN(){
                    pageSize = pg.pageSize,
                    currentPage = pg.currentPage
            }, ref rtMsg);

            return new rtData(rtMsg){
                list = COMMON.DataTableUtility.DataTableToList<M_ADMIN>(ds.Tables[0]),
                pagination = new Pagination(){
                    total = rtMsg.total,
                    pageSize = rtMsg.pageSize,
                    currentPage = rtMsg.currentPage,
                },
            };
        }

    }
}
