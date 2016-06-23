using System;
using System.Web;


/// <summary>
///ulCache 的摘要说明
/// </summary>
public class ulCache
{
	public ulCache()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
    }

    #region GetCache 读取缓存
    public static object GetCache(string cacheKey)
    {
        System.Web.Caching.Cache obj = HttpRuntime.Cache;  
        return obj[cacheKey];
    }

    public static string GetCacheString(string cacheKey)
    {
        try
        {
            System.Web.Caching.Cache obj = HttpRuntime.Cache;
            return (string)obj[cacheKey];
        }
        catch
        {
            return "";
        }
    }
    #endregion 

    #region SetCache 设置缓存
    public static bool SetCache(string cacheKey, object cacheObject, DateTime absoluteExpiration)
    {
        bool b = false;
        try
        {
            System.Web.Caching.Cache obj = HttpRuntime.Cache;
            obj.Insert(cacheKey, cacheObject, null, absoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
        }
        catch
        {
            b = false;
        }
        return b;
    }

    public static bool SetCache(string cacheKey, object cacheObject,TimeSpan slidingExpiration)
    {
        bool b = false;
        try
        {
            System.Web.Caching.Cache obj = HttpRuntime.Cache;
            obj.Insert(cacheKey, cacheObject, null, System.Web.Caching.Cache.NoAbsoluteExpiration, slidingExpiration);
        }
        catch
        {
            b = false;
        }
        return b;
    }

    public static bool SetCache(string cacheKey, object cacheObject, int ExpirationSeconds)
    {
        bool b = false;
        try
        {
            System.Web.Caching.Cache obj = HttpRuntime.Cache;
            obj.Insert(cacheKey, cacheObject, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(ExpirationSeconds));
        }
        catch
        {
            b = false;
        }
        return b;
    }
    #endregion 

}
