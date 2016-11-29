
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/PArticulo.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

PARTICULO_EXE_MDB_SOURCE=bin/Debug/PArticulo.exe.mdb
PARTICULO_EXE_MDB=$(BUILD_DIR)/PArticulo.exe.mdb
MYSQL_DATA_DLL_SOURCE=../../../../../usr/lib/cli/MySql.Data-6.4/MySql.Data.dll
ORG_INSTITUTOSERPIS_AD_DLL_SOURCE=../../Org.InstitutoSerpis.Ad/Org.InstitutoSerpis.Ad/bin/Debug/Org.InstitutoSerpis.Ad.dll
ORG_INSTITUTOSERPIS_AD_DLL_MDB_SOURCE=../../Org.InstitutoSerpis.Ad/Org.InstitutoSerpis.Ad/bin/Debug/Org.InstitutoSerpis.Ad.dll.mdb

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/PArticulo.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

PARTICULO_EXE_MDB=
MYSQL_DATA_DLL_SOURCE=../../../../../usr/lib/cli/MySql.Data-6.4/MySql.Data.dll
ORG_INSTITUTOSERPIS_AD_DLL_SOURCE=../../Org.InstitutoSerpis.Ad/Org.InstitutoSerpis.Ad/bin/Debug/Org.InstitutoSerpis.Ad.dll
ORG_INSTITUTOSERPIS_AD_DLL_MDB_SOURCE=../../Org.InstitutoSerpis.Ad/Org.InstitutoSerpis.Ad/bin/Debug/Org.InstitutoSerpis.Ad.dll.mdb

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(PARTICULO_EXE_MDB) \
	$(MYSQL_DATA_DLL) \
	$(ORG_INSTITUTOSERPIS_AD_DLL) \
	$(ORG_INSTITUTOSERPIS_AD_DLL_MDB)  

BINARIES = \
	$(PARTICULO)  


RESGEN=resgen2

MYSQL_DATA_DLL = $(BUILD_DIR)/MySql.Data.dll
ORG_INSTITUTOSERPIS_AD_DLL = $(BUILD_DIR)/Org.InstitutoSerpis.Ad.dll
ORG_INSTITUTOSERPIS_AD_DLL_MDB = $(BUILD_DIR)/Org.InstitutoSerpis.Ad.dll.mdb
PARTICULO = $(BUILD_DIR)/particulo

FILES = \
	gtk-gui/generated.cs \
	MainWindow.cs \
	gtk-gui/MainWindow.cs \
	Program.cs \
	Properties/AssemblyInfo.cs \
	Articulo.cs \
	ArticuloView.cs \
	gtk-gui/PArticulo.ArticuloView.cs \
	Categoria.cs \
	ArticuloDao.cs \
	CategoriaDao.cs 

DATA_FILES = 

RESOURCES = \
	gtk-gui/gui.stetic 

EXTRAS = \
	particulo.in 

REFERENCES =  \
	System \
	-pkg:gtk-sharp-2.0 \
	-pkg:glib-sharp-2.0 \
	-pkg:glade-sharp-2.0 \
	Mono.Posix \
	System.Data

DLL_REFERENCES =  \
	../../../../../usr/lib/cli/MySql.Data-6.4/MySql.Data.dll \
	../../Org.InstitutoSerpis.Ad/Org.InstitutoSerpis.Ad/bin/Debug/Org.InstitutoSerpis.Ad.dll

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,MYSQL_DATA_DLL))
$(eval $(call emit-deploy-target,ORG_INSTITUTOSERPIS_AD_DLL))
$(eval $(call emit-deploy-target,ORG_INSTITUTOSERPIS_AD_DLL_MDB))
$(eval $(call emit-deploy-wrapper,PARTICULO,particulo,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(PARTICULO_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(MYSQL_DATA_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ORG_INSTITUTOSERPIS_AD_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ORG_INSTITUTOSERPIS_AD_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(bindir)'
	$(call cp,$(PARTICULO),$(DESTDIR)$(bindir))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(PARTICULO_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MYSQL_DATA_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ORG_INSTITUTOSERPIS_AD_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ORG_INSTITUTOSERPIS_AD_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(PARTICULO),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
