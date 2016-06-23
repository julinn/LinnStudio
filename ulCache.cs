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
    /// <summary>
    /// 读取缓存对象
    /// </summary>
    /// <param name="cacheKey"></param>
    /// <returns></returns>
    public static object GetCache(string cacheKey)
    {
        System.Web.Caching.Cache obj = HttpRuntime.Cache;  
        return obj[cacheKey];
    }

    /// <summary>
    /// 读取缓存字符串
    /// </summary>
    /// <param name="cacheKey"></param>
    /// <returns></returns>
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
    /// <summary>
    /// 设置绝对过期时间缓存
    /// </summary>
    /// <param name="cacheKey"></param>
    /// <param name="cacheObject"></param>
    /// <param name="absoluteExpiration"></param>
    /// <returns></returns>
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
    /// <summary>
    /// 设置相对过期时间缓存
    /// </summary>
    /// <param name="cacheKey"></param>
    /// <param name="cacheObject"></param>
    /// <param name="slidingExpiration"></param>
    /// <returns></returns>
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
    /// <summary>
    /// 设置相对过期时间缓存（秒）
    /// </summary>
    /// <param name="cacheKey"></param>
    /// <param name="cacheObject"></param>
    /// <param name="ExpirationSeconds"></param>
    /// <returns></returns>
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
