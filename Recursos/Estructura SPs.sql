CREATE PROCEDURE XXX.uspGestionXXX (
	in intAccion tinyint,
	
)
begin
	if(intAccion = 1) then 
		-- Crear        		
		        
        select LAST_INSERT_ID(); 
	elseif (intAccion = 2) then 
		-- RecuperarFiltrado		
        
    elseif (intAccion = 3) then 
		-- Actualizar                
                
    elseif (intAccion = 4) then 
		-- Eliminar
		begin
			declare exit handler for 1451 -- update seguridad.empresa set activo = 0 where idempresa = intidempresa;
			
        end;
	end if;
end$$