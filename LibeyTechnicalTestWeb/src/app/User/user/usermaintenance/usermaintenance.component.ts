import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap, tap } from 'rxjs';
import { Region } from 'src/app/entities/region';
import { RegionService } from 'src/app/core/service/region/region.service';
import { Province } from 'src/app/entities/province';
import { Ubigeo } from 'src/app/entities/ubigeo';
import { DocumentUser } from 'src/app/entities/documentuser';

@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit {

  errorMessage = "";
  Listdocument: DocumentUser[] = [];
  Listregion: Region[] = [];
  Listprovince: Province[] = [];
  Listubigeo: Ubigeo[] = [];

  public libeyUserForm = new FormGroup({
    documentNumber:        new FormControl(''),
    documentTypeId:        new FormControl(null),
    name: new FormControl(''),
    fathersLastName: new FormControl(''),
    mothersLastName: new FormControl(''),
    address: new FormControl(''),
    regionCode: new FormControl(null),
    provinceCode:    new FormControl(null),
    ubigeoCode:    new FormControl(null),
    phone:    new FormControl(''),
    email:    new FormControl(''),
    password:    new FormControl(''),
  });

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private libeyUserService: LibeyUserService,
    private regionService: RegionService
  ) {}

  get currentLibayUser(): LibeyUser {
    const hero = this.libeyUserForm.value as LibeyUser;
    return hero;
  }

  ngOnInit(): void {
    this.getDocument();
    this.getRegions();
    this.onRegionChanged();
    this.onProvinceChanged();

    if ( !this.router.url.includes('edit') ) return;

    this.activatedRoute.params
      .pipe(
        switchMap( ({ id }) => this.libeyUserService.getFindById( id ) ),
      ).subscribe( user => {

        if ( !user ) {
          return this.router.navigateByUrl('/');
        }

        this.libeyUserForm.reset( user );
        return;
      });

  }

  getDocument(){
    this.libeyUserService.GetDocument()
    .subscribe(document => {
      this.Listdocument = document;
    });
   }

  getRegions(){
    this.regionService.GetRegion().subscribe({
      next: (regions) => {
        this.Listregion = regions;
      },
      error: (err) => (this.errorMessage = err),
    });
   }

  onRegionChanged(): void{

    this.libeyUserForm.get('regionCode')?.valueChanges.pipe(
      tap((_)=>{
        this.libeyUserForm.get('provinceCode')?.reset(null);
        this.libeyUserForm.get('ubigeoCode')?.reset(null);
      }),
      switchMap(provinces => this.regionService.GetProvince(provinces))
    ).subscribe(province => {
      this.Listprovince = province;
    })

   }

  onProvinceChanged(): void{

    this.libeyUserForm.get('provinceCode')?.valueChanges.pipe(
      tap((_)=>{
        this.libeyUserForm.get('ubigeoCode')?.reset(null);
      }),
      switchMap(ubigeos => this.regionService.GetUbigeo(ubigeos))
    ).subscribe(ubigeo => {
      this.Listubigeo = ubigeo;
    })

   }

  onSubmit():void{

    if ( this.libeyUserForm.invalid ) return;

    if ( this.router.url.includes('edit') ) {
      this.libeyUserService.updateUser( this.currentLibayUser )
        .subscribe( user => {
          return this.router.navigateByUrl('user/list');
        });

      return;
    }

    this.libeyUserService.addUser( this.currentLibayUser )
    .subscribe( user => {
      return this.router.navigateByUrl('user/list');
    });
  }

}
