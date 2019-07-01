using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebOa.Common;
using WebOa.Data;
using WebOa.Models;

namespace WebOa.Controllers
{
    public class KucunController : Controller
    {
        private readonly KucunContext Db;
        public KucunController(KucunContext kucunContext)
        {
            Db = kucunContext;
        }
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 控制器
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetKucunList()
        {
            List<KucunViewModel> kucunViewModels =  await GetKucunTable();
            return Json(kucunViewModels, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        #region 判断列表中是否已经有库存了
        /// <summary>
        /// 判断列表中是否已经有库存了
        /// </summary>
        /// <param name="server"></param>
        /// <param name="togetherKucun"></param>
        /// <returns></returns>
        private KucunViewModel isServerInList(string server, List<KucunViewModel> togetherKucun)
        {
            if (togetherKucun == null)
            {
                return null;
            }
            foreach (var kucun in togetherKucun)
            {
                if (kucun.server == server)
                {
                    return kucun;

                }
            }
            return null;
        }
        #endregion

        private async Task<List<KucunViewModel>> GetKucunTable()
        {
            List<KucunViewModel> togetherKucun = new List<KucunViewModel>();
            //首先获取实时库存并归类
            var temp = from u in Db.KucunTable
                       orderby u.updatetime
                       where u.kucun != 0
                       select new KucunViewModel
                       {
                           id = u.id,
                           dataServer = u.daqu,
                           server = u.fuwuqi,
                           oldGil = 0,
                           nowGil = u.kucun,
                           totalGil = u.kucun,
                           updataTime = TimeCommon.DateStringFromNowShupai(u.updatetime)
                       };
            togetherKucun = await temp.ToListAsync();
            //List<KucunViewModel> togetherKucun = await temp.Skip(0).Take(10).ToListAsync();
            //然后再获取转移库存列表
            var oldKucunTemp = from u in Db.OldHouse
                               where u.Gil != 0
                               select new KucunViewModel
                               {
                                   id = u.ID,
                                   dataServer = u.DataServer,
                                   server = u.Server,
                                   oldGil = u.Gil,
                                   nowGil = 0,
                                   totalGil = u.Gil,
                                   updataTime = TimeCommon.DateStringFromNow(u.CreateTime)
                               };
            //把得到的Temp转换成合并显示类型并加入List
            foreach (var oldGil in oldKucunTemp)
            {
                KucunViewModel oldKucun = isServerInList(oldGil.server, togetherKucun);//获取已经在实时库存中存在的服务器
                //如果存在
                if (oldKucun != null)
                {
                    oldKucun.id = oldGil.id;
                    oldKucun.oldGil += oldGil.oldGil;
                    oldKucun.totalGil = oldKucun.nowGil + oldKucun.oldGil;
                }
                //如果不存在
                else
                {
                    togetherKucun.Add(oldGil);
                }
            }
            return togetherKucun;
        }

        public async Task<IActionResult> GetKucunByServer(string server)
        {
            List<KucunViewModel> togetherKucun = new List<KucunViewModel>();         
            togetherKucun = await GetKucunTableByServer(server);                 
            return Json(togetherKucun, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        private async Task<List<KucunViewModel>> GetKucunTableByServer(string server)
        {
            List<KucunViewModel> togetherKucun = new List<KucunViewModel>();
            //首先获取实时库存并归类
            var temp = from u in Db.KucunTable
                       orderby u.updatetime
                       where u.kucun != 0
                       select new KucunViewModel
                       {
                           id = u.id,
                           dataServer = u.daqu,
                           server = u.fuwuqi,
                           oldGil = 0,
                           nowGil = u.kucun,
                           totalGil = u.kucun,
                           updataTime = TimeCommon.DateStringFromNow(u.updatetime)
                       };
            //挑选服务器部分
            switch (server)
            {
                case "usa":
                    temp = temp.Where(u => u.dataServer == "Aether" || u.dataServer == "Primal" || u.dataServer == "Crystal");
                    break;
                case "japan":
                    temp = temp.Where(u => u.dataServer == "Elemental" || u.dataServer == "Gaia" || u.dataServer == "Mana");
                    break;
                case "chaos":
                    temp = temp.Where(u => u.dataServer == "Chaos" || u.dataServer == "Light");
                    break;
                case "oumei":
                    temp = temp.Where(u => u.dataServer == "Aether" || u.dataServer == "Primal" || u.dataServer == "Chaos" || u.dataServer == "Crystal" || u.dataServer == "Light");
                    break;
                default:
                    break;
            }
            togetherKucun = await temp.ToListAsync();
            //List<KucunViewModel> togetherKucun = await temp.Skip(0).Take(10).ToListAsync();
            //然后再获取转移库存列表
            var oldKucunTemp = from u in Db.OldHouse
                               where u.Gil != 0
                               select new KucunViewModel
                               {
                                   id = u.ID,
                                   dataServer = u.DataServer,
                                   server = u.Server,
                                   oldGil = u.Gil,
                                   nowGil = 0,
                                   totalGil = u.Gil,
                                   updataTime = TimeCommon.DateStringFromNow(u.CreateTime)
                               };
            switch (server)
            {
                case "usa":
                    oldKucunTemp = oldKucunTemp.Where(u => u.dataServer == "Aether" || u.dataServer == "Primal" || u.dataServer == "Crystal");
                    break;
                case "japan":
                    oldKucunTemp = oldKucunTemp.Where(u => u.dataServer == "Elemental" || u.dataServer == "Gaia" || u.dataServer == "Mana");
                    break;
                case "chaos":
                    oldKucunTemp = oldKucunTemp.Where(u => u.dataServer == "Chaos" || u.dataServer == "Light");
                    break;
                case "oumei":
                    oldKucunTemp = oldKucunTemp.Where(u => u.dataServer == "Aether" || u.dataServer == "Primal" || u.dataServer == "Chaos" || u.dataServer == "Crystal" || u.dataServer == "Light");
                    break;
                default:
                    break;
            }
            //把得到的Temp转换成合并显示类型并加入List
            foreach (var oldGil in oldKucunTemp)
            {
                KucunViewModel oldKucun = isServerInList(oldGil.server, togetherKucun);//获取已经在实时库存中存在的服务器
                //如果存在
                if (oldKucun != null)
                {
                    oldKucun.id = oldGil.id;
                    oldKucun.oldGil += oldGil.oldGil;
                    oldKucun.totalGil = oldKucun.nowGil + oldKucun.oldGil;
                }
                //如果不存在
                else
                {
                    togetherKucun.Add(oldGil);
                }
            }
            return togetherKucun;
        }
    }
}