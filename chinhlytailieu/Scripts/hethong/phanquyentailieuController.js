app.controller("phanquyenController", function ($scope, $http) {
    $scope.nhomchucnang = "Phân quyền";
    $scope.chucnang = "Phân quyền truy cập tài liệu";

    $scope.disableCoQuan = true;
    $scope.currentPage = 1;
    $scope.showBtnSua = true;

    // load nhom nguoi dung
    $http({
        method: 'GET',
        url: '/hethong/ht_qlnhomnguoidung_Load'
    }).then(function (response) {
        //console.log(response.data);
        $scope.nhomnguoidung = response.data;
    }, function (reponse) {
        console.log("Lỗi không load được nhóm người dùng");
    })

    //click modal xac dinh them hay sua
    $scope.modallam = function (state) {
        $scope.state = state;
        if (state == "edit") {
            $scope.checkSua = true;
        }
        else { $scope.checkSua == false; }
    }

    $scope.save = function (state) {
        var path = null;
        var type = null;
        var status = null;
        if (state == "add") { path = "../quanlychucvuThemSua/"; type = 1; status = "Thêm thành công!"; }
        else if (state == "edit") {
            varIsConf = confirm('Bạn có chắc chắn muốn cập nhật lại thông tin của chức vụ có mã là: ' + $scope.cv.Machucvu + '?');
            if (varIsConf) {
                path = "../quanlychucvuThemSua"; type = 2; status = "Cập nhật thành công";
            }
        }
        //console.log(state);
        if (path != null) {
            $http({
                method: 'POST',
                url: path,
                data: { type: type, cv: $scope.cv }
            }).then(function success(response) {
                if (response.data == "1") {
                    alert(status);
                    $http({
                        method: 'GET',
                        url: '/hethong/DanhSachChucVu'
                    }).then(function (response) {
                        $scope.chucvu = response.data;
                    }, function (reponse) {
                        console.log("Lỗi không tải được danh sách chức vụ");
                    })
                }
                else {
                    console.log("Lỗi không thực hiện được chức năng");
                }
            })
        }
    }


    // click chon nhom
    $scope.click_nhom = function (n) {
        var t = document.getElementsByClassName('clicknhom');
        for (var i = 0; i < t.length; i++) {
            t[i].onclick = function () {
                for (var i = 0; i < t.length; i++) {
                    t[i].classList.remove('active_nhom');
                }
                this.classList.add('active_nhom')
            }
        }
        $scope.manhom = n.MANHOM; // lay ma nhom
        $scope.disableCoQuan = false;
        $scope.loadcoquan();
        
    }

    // click danh sach phong
    $scope.click_phong = function (d) {
        var maphong = d.MAPHONG;
        console.log(maphong);
        $http({
            method: 'POST',
            url: '/hethong/ht_phanquyen_loadQuyenTruyCap',
            data: { idphong: maphong }
        }).then(function (response) {
            console.log(response.data);
        })
    }

    // load phong khi chon co quan
    $(document).ready(function () {
        //selectcoquan();
        //selectphong();
    })

    $scope.loadcoquan = function () {
        $('select[name=select_coquan]').change(function () {
            if ($scope.manhom == null) {
                alert("Vui lòng chọn nhóm người dùng");
                $scope.disableCoQuan = true;
            }
            else {
                var idcoquan = $('select[name=select_coquan]').val();
                $http({
                    method: 'POST',
                    url: '/hethong/ht_phanquyen_loadPhongTheoCoquan',
                    data: { macoquan: idcoquan }
                }).then(function (response) {
                    $scope.danhsachPhong = response.data;
                    $scope.loadphong();
                }, function (response) {
                    alert("Lỗi không tải được danh sách phông");
                })
            }
        })
    }

    $scope.loadphong = function () {
        // chon phong hien thi danh sach tai khoan truy cap tai lieu
        $('select[name=select_phong]').change(function () {
            $scope.maphong = $('select[name=select_phong]').val();
            if ($scope.maphong == null) {
                $scope.DSTruyCapTaiLieu = null;
            }
            else {
                $http({
                    method: 'POST',
                    url: '/hethong/ht_phanquyen_loadPhong',
                    data: { maphong: $scope.maphong }
                }).then(function (response) {
                    console.log(response.data[0].TENMUCLUC);
                   
                    $scope.DSTruyCapTaiLieu = response.data;
                    $scope.dsth = {
                        XEM: false,
                        THEM: true,
                        SUA: false,
                        MAMUCLUC: response.data[0].MAMUCLUC,
                        TENMUCLUC: response.data[0].TENMUCLUC
                    }
                }, function (response) {
                    alert("Lỗi không tải được danh sách truy cập tài liệu");
                })
            }

        })
    }

    

    $scope.checkquyen = function () {
        $http({
            method: 'POST',
            url: '/hethong/ht_phanquyen_checkQuyenTruyCap',
            data: { maphong: $scope.maphong, manhom: $scope.manhom }
        }).then(function (response) {
            var DSquyen = response.data;
            var dscheck = document.getElementyId('truycapxem');
            console.log(dscheck);
        }, function (response) {
            alert("Lỗi không tải được danh sách truy cập tài liệu");
        })
    }

    $scope.ghinhan = function () {
        var xem = document.getElementsByClassName('truycapxem').value;
        var them = document.getElementsByClassName('truycapthem').value;
        var sua = document.getElementsByClassName('truycapsua').value;
        console.log(xem);
        console.log(them);
        console.log(sua);
    }

})
