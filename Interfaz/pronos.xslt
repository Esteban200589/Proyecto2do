<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
      
		<div class="table" style="overflow-y:scroll;height: 100%;margin-top:2%;">

			<div class="row" style="background-color:#958e69;font-size:12px;font-weight:bold;">
				<div class="col-md-2 col-sm-2 label" ><span>Hora</span></div>
				<div class="col-md-2 col-sm-2 label" ><span>Temp</span><span>(Max/Min)</span></div>
				<div class="col-md-3 col-sm-3 label" ><span>Lluvias</span>/<span>Tormentas</span></div>
				<div class="col-md-2 col-sm-2 label" style="text-align:left;" ><span>Viento</span></div>
				<div class="col-md-2 col-sm-2 label" style="text-align:left;"><span>Cielo</span></div>
			</div>
			
			<xsl:for-each select="Raiz/Pronostico_hora">							
				<div id="_ph_" class="row">

					<div  style="background-color:#FFFFCC;">
						<xsl:value-of select="ID"/>
					</div>
					
					<div class="col-md-2 col-sm-2" style="background-color:#FFFFCC">
						<xsl:value-of select="Hora" />
					</div>
					<div class="col-md-2 col-sm-3" style="background-color:white;">
						<div class="col-12" style="margin:0px;">
							<xsl:value-of select="Temp_Max" />
						</div>
						<div class="col-12" style="margin:0px;">
							<xsl:value-of select="Temp_Min" />
						</div>
					</div>
					<div class="col-md-2 col-sm-3" style="background-color:white;">
						<div class="col-12">
							<xsl:value-of select="Prob_Lluvias" />
						</div>
						<div class="col-12">
							<xsl:value-of select="Prob_Tormenta" />
						</div>
					</div>
					<div class="col-md-3 col-sm-3" style="background-color:white;">
						<xsl:value-of select="Velo_Viento" />
					</div>
					<div class="col-md-2 col-sm-3" style="font-size:11px;font-weight:bold;">
						<xsl:value-of select="Tipo_Cielo" />
					</div>
				
				</div>
			</xsl:for-each>
				
			
		</div>
		
    </xsl:template>
</xsl:stylesheet>
