﻿using Xioa.Admin.Request.Tools.Model;

namespace Xioa.Admin.Request.Tools.NetAxios;

public interface IAxios {
    
    public  HttpClient _httpClient { get; }
    
    #region GET请求

    Task<T?> GetAsync<T>(string url, object? parameters = null, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> GetAsync(string url, object? parameters = null, CancellationToken cancellationToken = default);

    #endregion

    #region POST请求

    Task<T?> PostAsync<T>(string url, object? data = null, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> PostAsync(string url, object? data = null, CancellationToken cancellationToken = default);

    #endregion

    #region PUT请求

    Task<T?> PutAsync<T>(string url, object? data = null, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> PutAsync(string url, object? data = null, CancellationToken cancellationToken = default);

    #endregion

    #region DELETE请求

    Task<T?> DeleteAsync<T>(string url, object? parameters = null, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> DeleteAsync(string url, object? parameters = null, CancellationToken cancellationToken = default);

    #endregion

    #region 拦截器

    void AddRequestInterceptor(Func<HttpRequestMessage, Task<HttpRequestMessage>> interceptor);
    void AddResponseInterceptor(Func<HttpResponseMessage, Task<HttpResponseMessage>> interceptor);

    #endregion
    
    
    #region 文件上传
    Task<T?> UploadAsync<T>(string url, Stream fileStream, string fileName, string? contentType = null, 
        Dictionary<string, string>? formData = null, CancellationToken cancellationToken = default,string apiFileName = "file");
    
    Task<T?> UploadAsync<T>(string url, IEnumerable<FileUploadContent> files, 
        Dictionary<string, string>? formData = null, CancellationToken cancellationToken = default,string apiFileName = "file");
    #endregion
}