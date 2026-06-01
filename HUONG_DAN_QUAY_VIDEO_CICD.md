# HUONG DAN QUAY VIDEO: CHAY KIEM THU TU DONG HOA CI/CD

Tai lieu nay dung de quay video tu dau den cuoi: mo project, chay web, chay automated test, upload len GitHub, chay GitHub Actions, va chay Azure DevOps Pipeline.

## 1. Tong Quan Noi Dung Video

Noi mo dau:

> Trong video nay, em se demo quy trinh kiem thu tu dong hoa CI/CD cho ung dung ASP.NET MVC .NET Framework 4.7.2. Quy trinh gom build project, chay unit test, integration test, performance test, dua source code len GitHub, va cau hinh pipeline tu dong.

Ket qua mong doi:

- Build solution: Success
- Unit Tests: 70 passed
- Integration Tests: 10 passed
- Performance Tests: 3 passed
- Total Automated Tests: 83 passed
- CI/CD artifact: WebApplication1-drop

## 2. Cac File Quan Trong Can Gioi Thieu

Mo Visual Studio 2022 va gioi thieu nhanh cac file:

- `ScholarshipService.cs`: xu ly logic nghiep vu.
- `Controllers\HomeController.cs`: xu ly request MVC.
- `Tests\ScholarshipServiceTests.cs`: unit test cho service.
- `Tests\HomeControllerTests.cs`: unit test cho controller.
- `Tests\IntegrationTests\HomeControllerIntegrationTests.cs`: integration test.
- `Tests\PerformanceTests\ServicePerformanceTests.cs`: performance test.
- `Tests\TestCaseCI_CD.xlsx`: bang test case va ket qua mong doi.
- `azure-pipelines.yml`: Azure DevOps CI/CD pipeline.
- `.github\workflows\ci-cd.yml`: GitHub Actions workflow.
- `.gitignore`: bo qua file build/output khi upload GitHub.

## 3. Cac Sua Doi Da Lam De Project Chay Dung

Noi trong video:

> Truoc khi chay CI/CD, em da chuan hoa lai project de pipeline co the build va test tu dong.

Da sua:

- Xoa project `..\TestCase\TestCase.csproj` bi thieu khoi `WebApplication1.sln`.
- Xoa launch profile cua project `TestCase` bi thieu khoi `WebApplication1.slnLaunch.user`.
- Sua `azure-pipelines.yml` de test dung file `bin\WebApplication1.dll`.
- Bo cau hinh `NuGet.config` vi repo khong co file nay.
- Cap nhat tong test dung thuc te: 83 automated tests.
- Them stage `Package Artifact` de tao goi deploy.
- Cap nhat `Tests\TestCaseCI_CD.xlsx` va `Test\TestCaseCI_CD.xlsx`.
- Them `.gitignore` de khong upload `bin`, `obj`, `packages`, `TestResults`, `.vs`.

## 4. Canh 1 - Chay Ung Dung Tren Visual Studio 2022

Thao tac:

1. Mo Visual Studio 2022.
2. Chon `Open a project or solution`.
3. Mo file `WebApplication1.sln`.
4. Tren thanh toolbar, chon `IIS Express`.
5. Bam nut Start.

Demo 3 chuc nang:

### Xet hoc bong

Nhap:

- GPA: `3.8`
- Diem ren luyen: `95`

Ket qua:

- `Xuat sac (Hoc bong loai 1)`

Noi:

> Chuc nang dau tien la xet hoc bong dua tren GPA va diem ren luyen.

### Dang ky su kien

Nhap:

- Tuoi: `20`
- Hang ve: `VIP`
- Ma giam gia: `STUDENT`

Ket qua:

- Thanh toan `400,000 VND`

Noi:

> Chuc nang thu hai la dang ky su kien, co xu ly loai ve va ma giam gia.

### Lien he

Nhap:

- Ho ten: `Nguyen Van A`
- Email: `test@example.com`
- So dien thoai: `0912345678`
- Noi dung: `Toi can ho tro ve he thong`

Ket qua:

- Gui lien he thanh cong.

Noi:

> Chuc nang thu ba kiem tra validation cua form lien he.

## 5. Canh 2 - Chay Automated Test Bang Test Explorer

Thao tac trong Visual Studio 2022:

1. Vao menu `Test`.
2. Chon `Test Explorer`.
3. Bam `Run All Tests`.
4. Doi test chay xong.
5. Zoom vao ket qua `83 Passed`.

Noi:

> Bo automated test gom 83 test case. Trong do co 70 unit test, 10 integration test va 3 performance test. Tat ca deu passed.

Nen show cac file test:

- `ScholarshipServiceTests.cs`: 55 service unit tests.
- `HomeControllerTests.cs`: 15 controller unit tests.
- `HomeControllerIntegrationTests.cs`: 10 integration tests.
- `ServicePerformanceTests.cs`: 3 performance tests.

## 6. Canh 3 - Chay Automated Test Bang Command Line

Mo `Developer PowerShell for VS 2022`.

Chay:

```powershell
cd C:\Users\84969\Downloads\SSIS_new\SSIS_new\SSAS_New\WebApplication1
```

Build solution:

```powershell
msbuild WebApplication1.sln /p:Configuration=Release /p:Platform="Any CPU"
```

Chay tat ca test:

```powershell
vstest.console.exe bin\WebApplication1.dll /Logger:trx /ResultsDirectory:TestResults\Video_All
```

Chay rieng Unit Tests:

```powershell
vstest.console.exe bin\WebApplication1.dll /TestCaseFilter:"TestCategory!=Integration&TestCategory!=Performance" /Logger:trx /ResultsDirectory:TestResults\Video_Unit
```

Chay rieng Integration Tests:

```powershell
vstest.console.exe bin\WebApplication1.dll /TestCaseFilter:"TestCategory=Integration" /Logger:trx /ResultsDirectory:TestResults\Video_Integration
```

Chay rieng Performance Tests:

```powershell
vstest.console.exe bin\WebApplication1.dll /TestCaseFilter:"TestCategory=Performance" /Logger:trx /ResultsDirectory:TestResults\Video_Performance
```

Noi:

> Cac lenh nay cung la y tuong ma pipeline CI/CD se tu dong chay tren build agent.

## 7. Canh 4 - Tao GitHub Repository Moi Tu Dau

Mo trinh duyet va vao GitHub.

Thao tac:

1. Dang nhap GitHub.
2. Bam dau `+` o goc tren phai.
3. Chon `New repository`.
4. Repository name: `WebApplication1-CICD`.
5. Description: `ASP.NET MVC automated testing CI/CD demo`.
6. Chon `Public` hoac `Private`.
7. Khong tick `Add a README file`.
8. Khong tick `.gitignore` tren GitHub vi project da co `.gitignore`.
9. Bam `Create repository`.

Noi:

> Em tao moi repository tren GitHub de dua toan bo source code len va kich hoat CI/CD.

Sau khi tao repo, GitHub se hien URL dang:

```text
https://github.com/<username>/WebApplication1-CICD.git
```

Copy URL nay de dung o buoc tiep theo.

## 8. Canh 5 - Upload Source Code Len GitHub Lan Dau

Mo `Developer PowerShell for VS 2022` tai thu muc project:

```powershell
cd C:\Users\84969\Downloads\SSIS_new\SSIS_new\SSAS_New\WebApplication1
```

Neu chua phai Git repo, chay:

```powershell
git init
```

Dat ten branch la `main`:

```powershell
git branch -M main
```

Kiem tra file se upload:

```powershell
git status
```

Them file vao commit:

```powershell
git add .
```

Tao commit dau tien:

```powershell
git commit -m "Initial CI/CD automated testing project"
```

Gan remote GitHub. Thay `<username>` bang username GitHub cua ban:

```powershell
git remote add origin https://github.com/<username>/WebApplication1-CICD.git
```

Push code len GitHub:

```powershell
git push -u origin main
```

Neu Git yeu cau dang nhap:

- Chon dang nhap bang browser, hoac
- Dung GitHub Personal Access Token neu Git yeu cau password.

Noi:

> Sau khi push thanh cong, source code da co tren GitHub. Do project co `.gitignore`, cac thu muc build nhu bin, obj, packages va TestResults se khong bi upload.

## 9. Canh 6 - Kiem Tra Code Tren GitHub

Tren GitHub repository, quay cac diem:

1. File `WebApplication1.sln`.
2. File `azure-pipelines.yml`.
3. Folder `.github/workflows`.
4. File `.github/workflows/ci-cd.yml`.
5. Folder `Tests`.
6. File `Tests/TestCaseCI_CD.xlsx`.

Noi:

> GitHub hien da luu source code, test code, test case va file cau hinh pipeline.

## 10. Canh 7 - Chay GitHub Actions CI

Sau khi push code len branch `main`, GitHub Actions se tu dong chay. Workflow cung da co `workflow_dispatch`, nen co the bam chay thu cong khi quay video.

Thao tac:

1. Vao tab `Actions`.
2. Chon workflow `CI/CD Pipeline`.
3. Bam vao run moi nhat.
4. Quay cac step:
   - Checkout source
   - Setup MSBuild
   - Restore NuGet packages
   - Build solution
   - Run unit tests
   - Run integration tests
   - Run performance tests
   - Upload test results
   - Upload build artifact

Noi:

> GitHub Actions la mot he thong CI/CD tich hop san tren GitHub. Moi lan push code len main, workflow se tu dong build va chay test.

Neu workflow chua tu chay hoac muon quay canh bam nut chay thu cong:

1. Vao tab `Actions`.
2. Chon `CI/CD Pipeline`.
3. Bam `Run workflow`.
4. Chon branch `main`.
5. Bam nut `Run workflow` mau xanh.

## 11. Canh 8 - Gioi Thieu Azure DevOps Pipeline

Mo file `azure-pipelines.yml`.

Giai thich:

```yaml
trigger:
  - main
  - develop
```

Noi:

> Pipeline se tu dong chay khi co code push vao branch main hoac develop.

Giai thich cac stage:

1. `Build`: restore NuGet, build solution, chay 70 unit tests.
2. `IntegrationTest`: chay 10 integration tests.
3. `Performance`: chay 3 performance tests.
4. `Package`: tao artifact deploy `WebApplication1-drop`.
5. `Summary`: in tong ket 83 automated tests.

Noi:

> Day la pipeline CI/CD chinh cua project. CI gom build va test. CD trong video nay duoc the hien bang buoc dong goi artifact san sang deploy.

## 12. Canh 9 - Tao Azure DevOps Pipeline Tu GitHub Repo

Tren Azure DevOps:

1. Vao project Azure DevOps.
2. Chon `Pipelines`.
3. Chon `New pipeline`.
4. Chon `GitHub`.
5. Dang nhap/authorize GitHub neu duoc hoi.
6. Chon repo `WebApplication1-CICD`.
7. Chon `Existing Azure Pipelines YAML file`.
8. Chon branch `main`.
9. Chon path `/azure-pipelines.yml`.
10. Bam `Continue`.
11. Bam `Run`.

Noi:

> Azure DevOps se doc file YAML trong GitHub repository va chay pipeline theo cac stage da cau hinh.

## 13. Canh 10 - Xem Ket Qua Azure Pipeline

Quay man hinh cac stage:

- Build
- IntegrationTest
- Performance
- Package
- Summary

Khi pipeline pass, mo:

1. Tab `Tests` de xem test results.
2. Tab `Artifacts` de xem `WebApplication1-drop`.

Noi:

> Ket qua pipeline pass chung minh quy trinh build, kiem thu tu dong va dong goi artifact da duoc tu dong hoa.

## 14. Canh 11 - Gioi Thieu File TestCaseCI_CD.xlsx

Mo file:

```text
Tests\TestCaseCI_CD.xlsx
```

Gioi thieu:

- Sheet `Summary`: tong hop so luong test.
- Sheet `TestCases`: danh sach test case.

Noi:

> File Excel nay dung de doi chieu giua test case va automated test. Hien co 83 automated tests va 5 dong kiem tra pipeline.

So lieu dung:

- Automated tests total: 83
- Unit tests: 70
- Integration tests: 10
- Performance tests: 3
- Pipeline validation checks: 5

## 15. Cau Noi Ket Video

Noi:

> Nhu vay, project da co quy trinh kiem thu tu dong hoa CI/CD. Source code duoc quan ly tren GitHub, GitHub Actions co the build va test tu dong, Azure DevOps Pipeline thuc hien build, unit test, integration test, performance test va tao artifact san sang deploy.

## 16. Loi Hay Gap Va Cach Sua

### Loi 1: Git bao chua cau hinh user

Neu commit bi loi, chay:

```powershell
git config --global user.name "Ten cua ban"
git config --global user.email "emailgithub@example.com"
```

Sau do commit lai:

```powershell
git commit -m "Initial CI/CD automated testing project"
```

### Loi 2: GitHub khong cho push bang password

GitHub khong dung password thuong cho Git HTTPS. Hay dang nhap bang browser hoac dung Personal Access Token.

### Loi 3: Pipeline khong tim thay test

Kiem tra trong `azure-pipelines.yml` phai co:

```yaml
testAssembly: '**\bin\WebApplication1.dll'
```

### Loi 4: Test Explorer khong hien test

Lam:

1. `Build > Rebuild Solution`.
2. `Test > Test Explorer`.
3. Bam refresh hoac `Run All Tests`.

### Loi 5: Azure DevOps khong thay GitHub repo

Lam:

1. Vao GitHub authorization cua Azure DevOps.
2. Cap quyen cho repo vua tao.
3. Quay lai Azure DevOps va chon repo lai.

## 17. Checklist Truoc Khi Quay

Truoc khi bam record:

- Visual Studio 2022 mo duoc `WebApplication1.sln`.
- Web chay duoc bang IIS Express.
- Test Explorer hien 83 tests.
- File `Tests\TestCaseCI_CD.xlsx` mo duoc.
- Da tao GitHub repo moi.
- Da copy GitHub repo URL.
- May da cai Git.
- Azure DevOps project da san sang neu muon quay pipeline.
