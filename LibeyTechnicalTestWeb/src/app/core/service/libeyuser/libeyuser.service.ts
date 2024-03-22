import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { environment } from "../../../../environments/environment";
import { LibeyUser } from "src/app/entities/libeyuser";
import { DocumentUser } from "src/app/entities/documentuser";

@Injectable({
	providedIn: "root",
})
export class LibeyUserService {

	constructor(private http: HttpClient) {}


  GetDocument(): Observable<DocumentUser[]> {
    return this.http.get<DocumentUser[]>(`${environment.pathLibeyTechnicalTest}LibeyUser/documentType`)
      .pipe(
        catchError(this.handleError)
      );
  }

  getFindById( id: string ): Observable<LibeyUser|undefined> {
    return this.http.get<LibeyUser>(`${environment.pathLibeyTechnicalTest}LibeyUser/${id}`)
    .pipe(
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  GetAll(): Observable<LibeyUser[]> {
    return this.http.get<LibeyUser[]>(`${environment.pathLibeyTechnicalTest}LibeyUser`)
  }

  addUser( user: LibeyUser ): Observable<LibeyUser> {
    console.log(user);
    return this.http.post<LibeyUser>(`${environment.pathLibeyTechnicalTest}LibeyUser`, user );
  }

  updateUser( user: LibeyUser ): Observable<LibeyUser> {
    return this.http.put<LibeyUser>(`${environment.pathLibeyTechnicalTest}LibeyUser`, user );
  }

  deleteUser( id : string ): Observable<boolean> {
    return this.http.delete<boolean>(`${environment.pathLibeyTechnicalTest}LibeyUser/${id}`);
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
