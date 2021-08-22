using System;

namespace AppDomainDemo
{
    public class AppDomainMonitorDelta : IDisposable
    {
        private AppDomain m_appDomain;
        private TimeSpan m_thisADCpu;
        private Int64 m_thisADMemoryInUse;
        private Int64 m_thisADMemoryAllocated;

        static AppDomainMonitorDelta() => AppDomain.MonitoringIsEnabled = true;

        public AppDomainMonitorDelta(AppDomain ad)
        {
            m_appDomain = ad ?? AppDomain.CurrentDomain;
            m_thisADCpu = m_appDomain.MonitoringTotalProcessorTime;
            m_thisADMemoryInUse = m_appDomain.MonitoringSurvivedMemorySize;
            m_thisADMemoryAllocated = m_appDomain.MonitoringTotalAllocatedMemorySize;
        }

        public void Dispose()
        {
            GC.Collect();
            Console.WriteLine("FriendlyName={0}, CPU={1}ms",
                m_appDomain.FriendlyName,
                (m_appDomain.MonitoringTotalProcessorTime - m_thisADCpu).TotalMilliseconds);
            Console.WriteLine(" Allocated {0:N0} bytes of which {1:N0} survived GCs",
                m_appDomain.MonitoringTotalAllocatedMemorySize - m_thisADMemoryAllocated,
                m_appDomain.MonitoringSurvivedMemorySize - m_thisADMemoryInUse);
        }
    }
}