create table votesystem_votos(
	id int NOT NULL,
	login varchar(250) NOT NULL,
	ip varchar(50) NOT NULL,
	data_voto DATETIME NOT NULL,
	PRIMARY KEY (id)
);

create table votesystem_tops(
	id int NOT NULL,
	link_votacao varchar(250) NOT NULL,
	nome_top varchar(150) NOT NULL,
	link_imagem varchar(250) NOT NULL,
	PRIMARY KEY (id)
);

create table votesystem_rewards(
	id int NOT NULL,
	item_id int NOT NULL,
	quantidade int NOT NULL,
	enchant_level int NOT NULL DEFAULT 0,
	PRIMARY KEY (id)
);