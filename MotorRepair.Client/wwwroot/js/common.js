window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Success", { timeOut: 5000 });
    }

    if (type === "error") {
        toastr.error(message, "Error", { timeOut: 5000 });
    }
}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}

var ShowModal = (id) => {
    $('#' + id).modal('show');
}

function HideModal(id) {
    $('#' + id).modal('hide');
}