package org.institutoserpis.org;

import javax.persistence.EntityManagerFactory;
import java.util.Calendar;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.Persistence;

public class Hibernate {

	public static void main(String[] args) {
		
		EntityManagerFactory entityManagerFactory =
				Persistence.createEntityManagerFactory("org.institutoserpis.ad.hmysql");
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
//		Categoria categoria = new Categoria();
//		categoria.setNombre("nueva" + Calendar.getInstance().getTime());
//		entityManager.persist(categoria);
//			System.out.printf("%d %s\n", item.getId(), item.getNombre()");
		
		
//		List<Categoria> categorias =
//				entityManager.createQuery("from Categoria", Categoria.class).getResultList();
//		for (Categoria item : categorias)
//			System.out.printf("%d %s\n", item.getId(), item.getNombre());
		
		Articulo articulo = entityManager.find(Articulo.class, 2L);
		
		//articulo.setNombre("modificado " + Calendar.getInstance().getTime());
		Categoria categoria = entityManager.find(Articulo.class, 1L);
		articulo.setCategoria(categoria);
		entityManager.persist(articulo);
		System.out.println(articulo);
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
		entityManagerFactory.close();
	}
	private static void show(Articulo articulo){
		System.out.printf("%s %-30 %s\n",
				articulo.getId(),articulo.getNombre(), articulo.getPrecio());
	}
}