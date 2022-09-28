using Microsoft.JSInterop;

namespace MotorRepair.Client.Helpers
{
  public static class IJSRuntimeExtension
  {
    public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message) {
      await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
    }

    public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string message) {
      await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
    }

    public static async ValueTask ShowDeleteModal(this IJSRuntime jSRuntime) {
      await jSRuntime.InvokeVoidAsync("ShowDeleteConfirmationModal");
    }

    public static async ValueTask HideDeleteModal(this IJSRuntime jSRuntime) {
      await jSRuntime.InvokeVoidAsync("HideDeleteConfirmationModal");
    }

    public static async ValueTask ShowModal(this IJSRuntime jsRunTime, string id) {
      await jsRunTime.InvokeVoidAsync("ShowModal", id);
    }

    public static async ValueTask HideModal(this IJSRuntime jsRunTime, string id) {
      await jsRunTime.InvokeVoidAsync("HideModal", id);
    }
  }
}
