package org.institutoserpis.org;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

public class Categoria {
	private long id;
	private String nombre;
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	
	public long getId() {
		return id;
	}
	public void setId(long id) {
		this.id = id;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	@Override
	public String toString() {
		
		return String.format("%s %s", id, nombre);
	}
	
}