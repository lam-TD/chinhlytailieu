app.controller("qlnhomnguoidungController", function ($scope, $http) {
    $scope.nhomchucnang = "Quản lý người dùng";
    $scope.chucnang = "Quản lý chức vụ";

    // load danh sach nhom nguoi dung
    $http.get('/hethong/ht_qlnhomnguoidung_Load').then(function (response) {
        $scope.nhomnguoidungLoad = response.data;
    }, function (response) {
        alert('Lỗi không tải được danh sách nhóm');
    })

    // load danh sach tai khoan trong nhom khi click chon nhom nguoi dung
    $scope.clickNhom = function (u) {
        var manhom = u.MANHOM;
        $scope.loadNhomnguoidung(manhom);
    }

    $scope.loadNhomnguoidung = function (manhom) {
        $http({
            method: 'POSt',
            url: '/hethong/ht_qlnhomnguoidung_LoadDSTaikhoan',
            data: { manhom: manhom}
        }).then(function (response) {
            $scope.taikhoan = response.data;
        })
    }

    //$http({
    //    method: 'GET',
    //    url: '/hethong/ht_qlnhomnguoidung_Loads'
    //}).then(function (response) {
    //    console.log(response);
    //    $scope.nhomnguoidungLoad = response.data;
    //})
})