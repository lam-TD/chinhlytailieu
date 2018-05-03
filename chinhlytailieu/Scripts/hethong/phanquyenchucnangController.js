app.controller("phanquyenchucnangController", function ($scope, $http) {
    $scope.nhomchucnang = "Phân quyền";
    $scope.chucnang = "Phân quyền truy cập tài liệu";

    $scope.disablePhanHe = true;
    

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
        $scope.idnhom = n.MANHOM;
        var t = document.getElementsByClassName('clicknhom');
        for (var i = 0; i < t.length; i++) {
            t[i].onclick = function () {
                for (var i = 0; i < t.length; i++) {
                    t[i].classList.remove('active_nhom');
                }
                this.classList.add('active_nhom')
            }
        }
        $scope.disablePhanHe = false;
        $scope.danhsachChucNang = null;
    }

    // load phan he
    $http({
        method: 'GET',
        url: '/hethong/ht_phanquyen_loadPhanHe'
    }).then(function (response) {
        $scope.phanhe = response.data;
    })

    // click chon phan he
    $scope.click_phanhe = function (p) {
        $scope.idPhanHe = p.ID;
        $http({
            method: 'POST',
            url: '/hethong/ht_phanquyen_loadChucNang',
            data: { moduleID: $scope.idPhanHe, type: 1 }
        }).then(function (response) {
            $scope.danhsachChucNang = response.data;
            checkChucNangThuocNhom($scope.idPhanHe);
        })
    }

    function checkChucNangThuocNhom(idphanhe) { 
      
        var DsChucNang; // danh sach tai khoan da thuoc nhom
        $http({
            method: 'POST',
            url: '/hethong/ht_phanquyen_loadChucNang',
            data: { moduleID: idphanhe, type: 2, manhom: $scope.idnhom }
        }).then(function (response) {
            DsChucNang = response.data;
       
            var DanhSachTaiKhoan = document.getElementsByClassName('checkChoPhep');

            for (var i = 0; i < DsChucNang.length; i++) {

                for (var j = 0; j < DanhSachTaiKhoan.length; j++) {
                    if (DsChucNang[i].Id == DanhSachTaiKhoan[j].value) {
                        DanhSachTaiKhoan[j].checked = true;
                    }
                }
            }
        })
    }

    // ghi nhan
    $scope.ghinhan = function () {
        var DanhSachChucNang = document.getElementsByClassName('checkChoPhep');
        var DSChuNangChoPhep = [];
        // lay chuc nang da duoc chon
        for (var i = 0; i < DanhSachChucNang.length; i++) {
            if (DanhSachChucNang[i].checked) {
                DSChuNangChoPhep.push(DanhSachChucNang[i].value);
            }
        }
        
        $http({
            method: 'POST',
            url: '/hethong/ht_phanquyen_GhiNhanChucNang',
            data: { idchucnang: DSChuNangChoPhep, manhom: $scope.idnhom }
        }).then(function (response) {
            if (response.data == "1") {
                alert("Ghi nhận thành công");
            }
            else { alert("Ghi nhận thất bại"); }
        })
    }
})
