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
    public class WebaddController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("[action]")]
        public rtData Add([FromBody]M_WEBADD form)
        {
            D_WEBADD dalObj = new D_WEBADD();
            TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);
            Console.WriteLine("UName:{0}, UCardid:{1}, UTeleNum:{2}", form.UName, form.UCardid, form.UTelenum);

            COMMON.MySqlRtMsg rtMsg = dalObj.Add(new M_WEBADD(){
                ID = 0,
                UName = form.UName,
                UCardid = form.UCardid,
                UTelenum = form.UTelenum,
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

            DataSet ds = new D_WEBADD().GetPagination(
                new M_WEBADD(){
                    pageSize = pg.pageSize,
                    currentPage = pg.currentPage
            }, ref rtMsg);

            return new rtData(rtMsg){
                list = COMMON.DataTableUtility.DataTableToList<M_WEBADD>(ds.Tables[0]),
                pagination = new Pagination(){
                    total = rtMsg.total,
                    pageSize = rtMsg.pageSize,
                    currentPage = rtMsg.currentPage,
                },
            };
        }

    }
}
