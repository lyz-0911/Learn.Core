using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace Learn.Core.Api.AOP
{
    /// <summary>
    /// 拦截器LogAOP
    /// </summary>
    public class LogAOP : IInterceptor
	{
        private readonly ILogger<LogAOP> _logger;
        public LogAOP(ILogger<LogAOP> logger)
		{
            _logger=logger; 
        }
        /// <summary>
        /// 实例化IInterceptor唯一方法 
        /// </summary>
        /// <param name="invocation">包含被拦截方法的信息</param>
        public void Intercept(IInvocation invocation)
        {

            // 事前处理: 在服务方法执行之前,做相应的逻辑处理
            var dataIntercept = "" +
                $"【当前执行方法】：{invocation.Method.Name} \r\n" +
                $"【携带的参数有】： {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())} \r\n";


			// 执行当前访问的服务方法,(注意:如果下边还有其他的AOP拦截器的话,会跳转到其他的AOP里)
			try
			{
                invocation.Proceed();
            }
			catch (Exception ex)
			{
                _logger.LogError(ex.Message);

            }
           

            // 事后处理: 在service被执行了以后,做相应的处理,这里是输出到日志文件
            dataIntercept += ($"【执行完成结果】：{invocation.ReturnValue}");

            // 输出到日志文件
            //Parallel.For(0, 1, e =>
            //{
            //    _logger.("AOPLog", new string[] { dataIntercept })
            //    LogLock.OutSql2Log("AOPLog", new string[] { dataIntercept });
            //});

        }
    }
}
