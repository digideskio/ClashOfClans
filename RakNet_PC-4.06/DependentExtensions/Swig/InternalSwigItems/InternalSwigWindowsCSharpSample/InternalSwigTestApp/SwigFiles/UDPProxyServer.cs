/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.1
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace RakNet {

using System;
using System.Runtime.InteropServices;

public class UDPProxyServer : PluginInterface2 {
  private HandleRef swigCPtr;

  internal UDPProxyServer(IntPtr cPtr, bool cMemoryOwn) : base(RakNetPINVOKE.UDPProxyServer_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(UDPProxyServer obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~UDPProxyServer() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          RakNetPINVOKE.delete_UDPProxyServer(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public static UDPProxyServer GetInstance() {
    IntPtr cPtr = RakNetPINVOKE.UDPProxyServer_GetInstance();
    UDPProxyServer ret = (cPtr == IntPtr.Zero) ? null : new UDPProxyServer(cPtr, false);
    return ret;
  }

  public static void DestroyInstance(UDPProxyServer i) {
    RakNetPINVOKE.UDPProxyServer_DestroyInstance(UDPProxyServer.getCPtr(i));
  }

  public UDPProxyServer() : this(RakNetPINVOKE.new_UDPProxyServer(), true) {
  }

  public void SetSocketFamily(ushort _socketFamily) {
    RakNetPINVOKE.UDPProxyServer_SetSocketFamily(swigCPtr, _socketFamily);
  }

  public void SetResultHandler(UDPProxyServerResultHandler rh) {
    RakNetPINVOKE.UDPProxyServer_SetResultHandler(swigCPtr, UDPProxyServerResultHandler.getCPtr(rh));
  }

  public bool LoginToCoordinator(RakString password, SystemAddress coordinatorAddress) {
    bool ret = RakNetPINVOKE.UDPProxyServer_LoginToCoordinator(swigCPtr, RakString.getCPtr(password), SystemAddress.getCPtr(coordinatorAddress));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public UDPForwarder udpForwarder {
    set {
      RakNetPINVOKE.UDPProxyServer_udpForwarder_set(swigCPtr, UDPForwarder.getCPtr(value));
    } 
    get {
      IntPtr cPtr = RakNetPINVOKE.UDPProxyServer_udpForwarder_get(swigCPtr);
      UDPForwarder ret = (cPtr == IntPtr.Zero) ? null : new UDPForwarder(cPtr, false);
      return ret;
    } 
  }

}

}
