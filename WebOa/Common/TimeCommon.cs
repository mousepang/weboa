﻿using System;

namespace WebOa.Common
{
    public static class TimeCommon
    {

        //使用C#把发表的时间改为几个月,几天前,几小时前,几分钟前,或几秒前
        //2008年03月15日 星期六 02:35
        public static string DateStringFromNow(DateTime dt)
        {
            TimeSpan span = DateTime.Now.ToUniversalTime() - dt.AddHours(-8);
            if (span.TotalDays > 60)
            {
                return dt.ToString();
            }
            else
            {
                if (span.TotalDays > 30)
                {
                    return
                    "1个月前";
                }
                else
                {
                    if (span.TotalDays > 14)
                    {
                        return
                        "2周前";
                    }
                    else
                    {
                        if (span.TotalDays > 7)
                        {
                            return
                            "1周前";
                        }
                        else
                        {
                            if (span.TotalDays > 1)
                            {
                                return
                                string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                            }
                            else
                            {
                                if (span.TotalHours > 1)
                                {
                                    return
                                    string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                                }
                                else
                                {
                                    if (span.TotalMinutes > 1)
                                    {
                                        return
                                        string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                                    }
                                    else
                                    {
                                        if (span.TotalSeconds >= 1)
                                        {
                                            return
                                            string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                                        }
                                        else
                                        {
                                            return
                                            "1秒前";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static string DateStringFromNowShupai(DateTime dt)
        {
            TimeSpan span = DateTime.Now.ToUniversalTime() - dt.AddHours(-8);
            if (span.TotalDays > 60)
            {
                return dt.ToString();
            }
            else
            {
                if (span.TotalDays > 30)
                {
                    return
                    "1个月前";
                }
                else
                {
                    if (span.TotalDays > 14)
                    {
                        return
                        "2周前";
                    }
                    else
                    {
                        if (span.TotalDays > 7)
                        {
                            return
                            "1周前";
                        }
                        else
                        {
                            if (span.TotalDays > 1)
                            {
                                return
                                string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                            }
                            else
                            {
                                if (span.TotalHours > 1)
                                {
                                    return
                                    string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                                }
                                else
                                {
                                    if (span.TotalMinutes > 1)
                                    {
                                        return
                                        string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                                    }
                                    else
                                    {
                                        if (span.TotalSeconds >= 1)
                                        {
                                            return
                                            string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                                        }
                                        else
                                        {
                                            return
                                            "1秒前";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
