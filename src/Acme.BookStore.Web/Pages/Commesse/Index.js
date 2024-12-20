$(function () {
    var l = abp.localization.getResource('BookStore');
    var createModal = new abp.ModalManager(abp.appPath + 'Commesse/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Commesse/EditModal');

    var dataTable = $('#CommesseTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.bookStore.commesse.commessa.getFullList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible:
                                        abp.auth.isGranted('BookStore.Commesse.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible:
                                        abp.auth.isGranted('BookStore.Commesse.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'CommessaDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        acme.bookStore.commesse.commessa
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Nome'),
                    data: "nome"
                },
                {
                    title: l('Tipologia'),
                    data: "tipologia",
                    render: function (data) {
                        return l('Enum:Tipologia.' + data);
                    }
                },
                {
                    title: l('Cliente'),
                    data: "cliente"
                },
                {
                    title: l('Totale'),
                    data: "totale"
                },
                {
                    title: l('IsActive'),
                    data: "isActive"
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCommessaButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});