<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
        <!--<xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>-->

		<div class="table" style="overflow-y:scroll;height: 100%;">
			
			<xsl:for-each select="Pronostico_Tiempo | node()">

				<div class="row">
					<div class="col-3 pais" style="background-color:#CCCCCC;height:46px;text-align:left;">
						<div style="padding-top:10px;font-weight:bold;padding-left:10px;">
							<xsl:value-of select="Pais" />
						</div>
					</div>
					<div class="col-9 ciudad" style="background-color:#CCCCCC;height:46px;text-align:left;">
						<div style="padding-top:10px;font-weight:bold;padding-left:10px;">
							<xsl:value-of select="Ciudad" />
						</div>
					</div>
					<div class="col-md-12 col-sm-12 hora" style="background-color:white;border-width:1px;border-style:solid;text-align:left;">

            <div class="row" style="background-color:#958e69">
              <div class="col-md-2 col-sm-2 label" >Hora</div>
              <div class="col-md-2 col-sm-3 label" >Temperaturas (Max/Min)</div>
              <div class="col-md-2 col-sm-3 label" >Lluvias/Tormentas</div>
              <div class="col-md-3 col-sm-2 label" >Viento</div>
              <div class="col-md-3 col-sm-3 label" >Cielo</div>
            </div>
            
						<xsl:for-each select="Root/Pronostico_Tiempo/Pronostico_Hora  | node()">						
							<div class="row">
								<div class="col-md-2 col-sm-2" style="background-color:#FFFFCC">
									<xsl:value-of select="Hora" />
								</div>
                <div class="col-md-2 col-sm-3" >
                  <div class="col-12">
                    <xsl:value-of select="Temp_Max" />
                  </div>
                  <div class="col-12">
                    <xsl:value-of select="Temp_Min" />
                  </div>
                </div>
                <div class="col-md-2 col-sm-3">
                  <div class="col-12">
                    <xsl:value-of select="Prob_Lluvias" />
                  </div>
                  <div class="col-12">
                    <xsl:value-of select="Prob_Tormenta" />
                  </div>
                </div>
                <div class="col-md-3 col-sm-3">
                  <xsl:value-of select="Velo_Viento" />
                </div>
                <div class="col-md-3 col-sm-3">
                  <xsl:value-of select="Tipo_Cielo" />
                </div>
							</div>
						</xsl:for-each>
					</div>
				</div>

			</xsl:for-each>
		</div>
		
    </xsl:template>
</xsl:stylesheet>
