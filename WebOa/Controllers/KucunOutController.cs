using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebOa.Data;
using WebOa.Models.ViewModels;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace WebOa.Controllers
{
    public class KucunOutController : Controller
    {
        private readonly KucunContext Db;
        public KucunOutController(KucunContext kucunContext)
        {
            Db = kucunContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        private int GetGil(int outGil, byte flag)
        {
            if (flag == 0)
            {
                return -outGil;
            }
            return outGil;
        }

        private string ChangeFlag(byte flag)
        {
            if (flag == 1)
            {
                return "取钱";
            }
            return "存钱";
        }

        private async Task<List<KucunOutView>> GetOutList()
        {
            var temp = from u in Db.KucunOutHistory.OrderByDescending(u=>u.id).Take(100)
                       orderby u.created_time
                       select new KucunOutView
                       {
                           id = u.id,
                           dataServer = u.daqu,
                           server = u.server,
                           outGil = GetGil(u.outGil, u.flag),
                           created_time = u.created_time.AddHours(8),
                           nowKucun = u.nowKucun / 1000,
                           name = u.name,
                           game_time = u.game_time,
                           flag = ChangeFlag(u.flag),
                       };
            return await temp.ToListAsync();
        }

        private async Task<List<KucunOutView>> GetKucunSalesByDate(DateTime timeFrom, DateTime timeTo)
        {
            var temp = from u in Db.KucunOutHistory
                       orderby u.created_time
                       where (DateTime.Compare(u.created_time.AddHours(8), timeFrom) > 0 && DateTime.Compare(u.created_time.AddHours(8), timeTo.AddDays(1)) < 0)
                       select new KucunOutView
                       {
                           id = u.id,
                           dataServer = u.daqu,
                           server = u.server,
                           outGil = GetGil(u.outGil, u.flag),
                           created_time = u.created_time.AddHours(8),
                           nowKucun = u.nowKucun / 1000,
                           name = u.name,
                           game_time = u.game_time,
                           flag = ChangeFlag(u.flag),
                       };
            return await temp.ToListAsync();
        }

        public async Task<IActionResult> GetSalesByData(DateTime? start, DateTime? end)
        {
            if (start == null)
            {
                start = DateTime.Now.Date;
            }
            if (end == null)
            {
                end = DateTime.Now.Date;
            }
            List<KucunOutView> SalesHistoryList = new List<KucunOutView>();
            SalesHistoryList = await GetKucunSalesByDate((DateTime)start, (DateTime)end);
            //过滤掉抢钱的部分
            for (int i = SalesHistoryList.Count - 1; i >= 0; i--)
            {
                if (SalesHistoryList[i].flag == "存钱" && SalesHistoryList[i].outGil < 101)
                    SalesHistoryList.Remove(SalesHistoryList[i]);
            }
            return Json(SalesHistoryList, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        public async Task<IActionResult> GetKucunOutList(string userName)
        {
            List<KucunOutView> SalesHistoryList = new List<KucunOutView>();

            SalesHistoryList = await GetOutList();
            //过滤掉抢钱的部分
            for (int i = SalesHistoryList.Count - 1; i >= 0; i--)
            {
                if (SalesHistoryList[i].flag == "存钱" && SalesHistoryList[i].outGil < 101)
                    SalesHistoryList.Remove(SalesHistoryList[i]);
            }
            return Json(SalesHistoryList, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}