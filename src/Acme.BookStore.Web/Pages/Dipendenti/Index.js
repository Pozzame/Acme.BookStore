$(function () {
    var l = abp.localization.getResource('BookStore');
    var createModal = new abp.ModalManager(abp.appPath + 'Dipendenti/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Dipendenti/EditModal');

    var dataTable = $('#DipendentiTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.bookStore.dipendenti.dipendente.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible:
                                        abp.auth.isGranted('BookStore.Dipendenti.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible:
                                        abp.auth.isGranted('BookStore.Dipendenti.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'DipendenteDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        acme.bookStore.dipendenti.dipendente
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
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Surname'),
                    data: "surname"
                },
                {
                    title: l('BirthDate'),
                    data: "birthDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                {
                    title: l('StartDate'),
                    data: "startDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.surname
                            }).toLocaleString();
                    }
                },
                {
                    title: l('HourlyRate'),
                    data: "hourlyRate"
                    //render: function (data) {
                    //    // Assumendo che `abp.localization.currentCulture.name` sia ad esempio "it-IT"
                    //    const formatter = new Intl.NumberFormat(abp.localization.currentCulture.name, {
                    //        style: 'currency',
                    //        currency: 'EUR' // Modifica con la valuta desiderata, ad esempio "USD" per dollari
                    //    });

                    //    return formatter.format(data);
                    //}
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

    $('#NewDipendenteButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});