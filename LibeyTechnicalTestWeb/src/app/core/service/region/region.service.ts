import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { environment } from "../../../../environments/environment";
import { Region } from "src/app/entities/region";
import { Province } from "src/app/entities/province";
import { Ubigeo } from "src/app/entities/ubigeo";
@Injectable({
	providedIn: "root",
})
export class RegionService {

	constructor(private http: HttpClient) {}

  GetRegion(): Observable<Region[]> {
    return this.http.get<Region[]>(`${environment.pathLibeyTechnicalTest}Region`)
      .pipe(
        catchError(this.handleError)
      );
  }

  GetProvince(code: string): Observable<Province[]> {
    return this.http.get<Province[]>(`${environment.pathLibeyTechnicalTest}Region/province/code/${code}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  GetUbigeo(code: string): Observable<Ubigeo[]> {
    return this.http.get<Ubigeo[]>(`${environment.pathLibeyTechnicalTest}Region/ubigeo/code/${code}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(err:any) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }
}
