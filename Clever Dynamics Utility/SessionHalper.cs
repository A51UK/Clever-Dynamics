using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Clever_Dynamics_Utility
{
        public class SessionHalper
        {


            public void SetString(string key, string _string, HttpContext _httpContext)
            {
                _httpContext.Session.Set(key, System.Text.Encoding.UTF8.GetBytes(_string));
                _httpContext.Session.CommitAsync();
            }

            public async Task<string> GetStringAsync(string key, HttpContext _httpContext)
            {
                string thisString = string.Empty;
                byte[] thisByte = null;

                await _httpContext.Session.LoadAsync();
                if (_httpContext.Session.TryGetValue(key, out thisByte))
                {
                    thisString = System.Text.Encoding.UTF8.GetString(thisByte);
                }

                return thisString;
            }

            public void SetInt(string key, int _int, HttpContext _httpContext)
            {
                _httpContext.Session.Set(key, System.Text.Encoding.UTF8.GetBytes(_int.ToString()));
                _httpContext.Session.CommitAsync();
            }

            public async Task<int?> GetIntAsync(string key, HttpContext _httpContext)
            {
                int? _int = null;
                byte[] thisByte = null;

                await _httpContext.Session.LoadAsync();
                if (_httpContext.Session.TryGetValue(key, out thisByte))
                {
                    _int = int.Parse(System.Text.Encoding.UTF8.GetString(thisByte));
                }

                return _int;
            }

            public async void SetObject<T>(string key, T _object, HttpContext _httpContext)
            {
                string json = JsonConvert.SerializeObject(_object);

                _httpContext.Session.Set(key, System.Text.Encoding.UTF8.GetBytes(json));
                await _httpContext.Session.CommitAsync();
            }

            public async Task<T> GetObjectAsync<T>(string key, HttpContext _httpContext)
            {
                T _object = default(T);
                byte[]? thisByte = null;

                await _httpContext.Session.LoadAsync();
                if (_httpContext.Session.TryGetValue(key, out thisByte))
                {
                    _object = (T)JsonConvert.DeserializeObject(System.Text.Encoding.UTF8.GetString(thisByte), typeof(T));
                }

                return _object;
            }

            public void Remove(string key, HttpContext _httpContext)
            {
                _httpContext.Session.Remove(key);
            }

        }

}